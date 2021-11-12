<template>
	<div class="container-fluid">
		<div class="row justify-content-center">
			<div class="col-11 col-sm-9 col-md-7 col-lg-6 col-xl-5 text-center px-3 mt-3 mb-2" id="sign-up">
				<div class="card px-0 pt-4 pb-0 mt-3 mb-3">
					<h2 id="heading"> Sign Up Your User Account </h2>

					<p>Fill all form field to go to next step</p>

					<form id="msform">
						<ul id="progressbar">
							<li class="active" id="account">
								<b-icon icon="pen" font-scale="1.5"></b-icon>
								<strong>Account</strong>
							</li>

							<li id="camera">
								<b-icon icon="camera" font-scale="1.5"></b-icon>
								<strong>Camera</strong>
							</li>
						</ul> <hr/> <br/>
						
						<fieldset class="tab">
							<div class="form-card">
								<div class="row">
									<div class="col-7">
										<h2 class="fs-title">Account Information:</h2>
									</div>
									<div class="col-5">
										<h2 class="steps">Step 1 - 3</h2>
									</div>
								</div> 
								
								<label class="fieldlabels">Name: *</label>
								<input type="text" v-model="userInfo.name" name="name" placeholder="Name" />

								<label class="fieldlabels">Username: *</label>
								<input type="text" v-model="userInfo.username" name="username" placeholder="Username" /> 
								
								<label class="fieldlabels">Password: *</label> 
								<input type="password" v-model="userInfo.password" name="password" placeholder="Password" /> 
								
								<label class="fieldlabels"> Position:* </label> <br/>
								<select v-model="userInfo.id_user_position" class="mt-2" name="Setor">
									<option value="1"> Minister </option>						
									<option value="2"> Manager </option>
									<option value="3"> Official </option>
								</select>
							</div>

							<button type="button" @click="nextPrev(1)" name="next" class="next action-button mt-4"> 
								Next
							</button>
						
							<b-button :to="{name: 'login'}" type="button" name="previous" class="button-login mt-4 mr-3">
								Login
							</b-button>
						</fieldset>

						<fieldset class="tab">
							<div class="form-card">
								<div class="row">
									<div class="col-7">
										<h2 class="fs-title">Images Upload:</h2>
									</div>

									<div class="col-5">
										<h2 class="steps">Step 2 - 3</h2>
									</div>
								</div>
							</div> 

							<div class="d-flex justify-content-center">
								<ImageCapture @photos-list="getPhotos" />
							</div>

							<button :disabled="!hasThreeImages" type="button" @click="send(), nextPrev(1)" name="next" class="next action-button">
								Submit
							</button>

							<button type="button" @click="nextPrev(-1)" name="previous" class="previous action-button-previous">
								Previous
							</button>

							<b-button :to="{name: 'login'}" type="button" name="previous" variant="primary" class="button-login mr-3">
								Login
							</b-button>
						</fieldset>

						<fieldset class="tab">
							<div class="form-card">
								<div class="row">
									<div class="col-7">
										<h2 class="fs-title">Finish:</h2>
									</div>
									<div class="col-5">
										<h2 class="steps">Step 3 - 3</h2>
									</div>
								</div> <br/> <br/>

								<h2 class="green-text text-center">
									<strong> SUCCESS ! </strong>
								</h2> <br/>
								
								<div class="row justify-content-center">
									<div class="col-3"> 
										<img src="https://www.pinclipart.com/picdir/big/546-5469594_green-checklist-png-small-green-check-icon-clipart.png" class="fit-image" /> 
									</div>
								</div> <br/> <br/>

								<div class="row justify-content-center">
									<div class="col-7 text-center">
										<h5 class="green-text text-center">
											You Have Successfully Signed Up
										</h5>
									</div>
								</div>
							</div>
						</fieldset>
					</form>
				</div>
			</div>
		</div>
	</div>
</template>

<script>
	import ImageCapture from './shared/ImageCapture.vue';

    export default {
  		components: {
			ImageCapture
		},

		data() {
			return {
				userInfo: {
					id_user: 0,
					name: '',
					username: '',
					password: '',
					id_user_position: 1,
					face_images: []
				},

				currentTab: 0
			}
		},

		methods: {
			send() {
				this.$requisicao.post('/user/register', this.userInfo)
					.then((response) => {
						if(response.status == 200) {
							setTimeout(() => {
								this.$router.push({name: 'login'});
							}, 3000);
						}
					})
			},

			getPhotos(photos) {
				this.userInfo.face_images = photos;
			},

			showTab(numberPage) {
				var fieldsSet = document.getElementsByClassName("tab");

				fieldsSet[numberPage].style.display = "block";
			},

			nextPrev(numberPage) {
				let fieldsSet = document.getElementsByClassName("tab");

				let iconAccount = document.querySelector('#account');
				let iconCamera = document.querySelector('#camera');

				if(numberPage == 1) {
					// Camera
					iconAccount.classList.remove('active');

					iconCamera.classList.add('active');
				} else {
					// Account
					iconCamera.classList.remove('active');

					iconAccount.classList.add('active');
				}

				fieldsSet[this.currentTab].style.display = "none";
				
				this.currentTab += numberPage;

				if(this.currentTab >= fieldsSet.length) {
					return false;
				}
				
				this.showTab(this.currentTab);
			}
		},

		mounted() {
			this.showTab(this.currentTab);
		},

		computed: {
			hasThreeImages() {
				return this.userInfo.face_images.length == 3;
			}
		}
    }
</script>

<style scoped>
	* {
		margin: 0;
		padding: 0
	}

	.button-login {
		width: 100px;
		font-weight: bold;
		color: white;
		border: 0 none;
		border-radius: 0px;
		cursor: pointer;
		padding: 10px 5px;
		margin: 10px 5px 10px 0px;
		float: right;
		background: #428bca;
	}

	.button-login:hover {
		background: #151B54;
	}

	.btn-submit-disabled {
		background: #98FB98;
	}

	#sign-up {
		border: 0.5px solid lightgray !important;
		border-radius: 10px !important;
	}

	html {
		height: 100%
	}

	p {
		color: grey
	}

	#heading {
		text-transform: uppercase;
		color: #57bb57;
		font-weight: normal
	}

	.btn-next-disabled {
		background: #98FB98;
	}

	#msform {
		text-align: center;
		position: relative;
		margin-top: 20px
	}

	#msform fieldset {
		background: white;
		border: 0 none;
		border-radius: 0.5rem;
		box-sizing: border-box;
		width: 100%;
		margin: 0;
		padding-bottom: 20px;
		position: relative
	}

	.form-card {
		text-align: left
	}

	#msform fieldset:not(:first-of-type) {
		display: none
	}

	#msform input, select #msform textarea {
		padding: 8px 15px 8px 15px;
		border: 1px solid #ccc;
		border-radius: 0px;
		margin-bottom: 25px;
		margin-top: 2px;
		width: 100%;
		box-sizing: border-box;
		font-family: montserrat;
		color: #2C3E50;
		background-color: #ECEFF1;
		font-size: 16px;
		letter-spacing: 1px
	}

	#msform input:focus, #msform textarea:focus {
		-moz-box-shadow: none !important;
		-webkit-box-shadow: none !important;
		box-shadow: none !important;
		border: 1px solid #40826D;
		outline-width: 0
	}

	/* Repetindo o código, pois, não funciona se como select:focus nos acima */
	#msform select:focus {
		border: 1px solid #40826D;
	}

	#msform select {
		padding: 8px 15px 8px 15px;
		border: 1px solid #ccc;
		border-radius: 0px;
		margin-bottom: 25px;
		margin-top: 2px;
		width: 100%;
		box-sizing: border-box;
		font-family: montserrat;
		color: #2C3E50;
		background-color: #ECEFF1;
		font-size: 16px;
		letter-spacing: 1px
	}

	#msform .action-button {
		width: 100px;
		background: #088F8F;
		font-weight: bold;
		color: white;
		border: 0 none;
		border-radius: 0px;
		cursor: pointer;
		padding: 10px 5px;
		margin: 10px 0px 10px 5px;
		float: right
	}

	#msform .action-button:hover, #msform .action-button:focus {
		background-color: #023020;
	}

	#msform .action-button-previous {
		width: 100px;
		background: #616161;
		font-weight: bold;
		color: white;
		border: 0 none;
		border-radius: 0px;
		cursor: pointer;
		padding: 10px 5px;
		margin: 10px 5px 10px 0px;
		float: right
	}

	#msform .action-button-previous:hover, #msform .action-button-previous:focus {
		background-color: #000000
	}

	.card {
		z-index: 0;
		border: none;
		position: relative
	}

	.fs-title {
		font-size: 25px;
		color: #2E8B57;
		margin-bottom: 15px;
		font-weight: normal;
		text-align: left
	}

	.green-text {
		color: #04AA6D;
		font-weight: normal
	}

	.steps {
		font-size: 25px;
		color: gray;
		margin-bottom: 10px;
		font-weight: normal;
		text-align: right
	}

	.fieldlabels {
		color: gray;
		text-align: left
	}

	#progressbar {
		margin-bottom: 30px;
		overflow: hidden;
		color: lightgrey
	}

	#progressbar .active {
		color: #088F8F;
	}

	#progressbar li {
		list-style-type: none;
		font-size: 15px;
		width: 25%;
		float: left;
		position: relative;
		font-weight: 400
	}

	.fit-image {
		width: 100%;
		object-fit: cover;
	}
</style>