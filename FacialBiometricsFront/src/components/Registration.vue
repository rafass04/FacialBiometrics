<template>
    <div id="registration">
		<div class="row">
			<div class="col-lg-5 border rounded mt-4 ml-5" id="form">
				<div class="row mt-1">
					<div class="col-lg-12 col-md-12 col-sm-12 text-center bg-primary rounded">
						<h3 class="title mt-1"> Registration </h3>
					</div>
				</div>

				<div class="row mt-1">
					<div class="col-lg-12 col-md-12 col-sm-12 text-center">
						<img src="../assets/register.jpg" height="300" width="550"  />
					</div>
				</div>
				
				<div class="row mt-1">
					<div class="col-lg-11 col-md-12 col-sm-12">
						<div class="form-group">
							<label class="font-weight-bold" for="name-user"> Name </label>

							<input type="text" v-model="userInfo.name_user" class="form-control" id="name-user" placeholder="name" />
						</div>
					</div>		
				</div>

				<div class="row mt-1">
					<div class="col-lg-6 col-md-10 col-sm-12">				
						<div class="form-group">				
							<label class="font-weight-bold" for="password-user">Enter Password</label>
							
							<input type="password" v-model="userInfo.password_user" class="form-control" id="password-user" placeholder="Password must be at least 8 digits long" />
						</div>
					</div>

					<div class="col-lg-6 col-md-10 col-sm-12">				
						<div class="form-group">				
							<label class="font-weight-bold" for="confirm-password">Confirm your Password</label>
							
							<input type="password" class="form-control" id="confirm-password" placeholder="confirm the password">
						</div>					
					</div>
				</div>			
			
				<div class="form-group">
					<label class="font-weight-bold" for="office-user"> Office </label>

					<select v-model="userInfo.id_user_position" class="form-control" id="office-user" name="Setor">
						<option value="1"> Minister </option>						
						<option value="2"> Manager </option>
						<option value="3"> Official </option>
					</select>
				</div>

				<div class="form-group text-center mt-4">
					<button type="submit" :disabled="!habilitaSubmit" class="btn btn-sm btn-primary mr-5" @click="submit"> 
						Register 
					</button>

					<router-link :to="{name: 'login'}">
						<button type="button" class="btn btn-sm btn-secondary"> 
							Back 
						</button>
					</router-link>
				</div>
			</div>

			<div class="col-lg-6 border rounded text-center mt-4 ml-2" id="take-photos">
				<div class="form-group mt-1">
					<h3 class="title bg-primary rounded p-1"> Images </h3>

					<ImageCapture @photos-list="getPhotos" />
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
					name_user: '',
					username_user: '',
					password_user: '',
					id_user_position: 1,
					images: []
				}
			}
		},

		computed: {
			canReleaseCamera() {
				if(this.userInfo.name_user != '' && this.userInfo.password_user.length >= 8) {
					return true;
				}

				return false;
			},

			habilitaSubmit() {
				return this.userInfo.images.length == 3;
			}
		},

        methods: {
			submit() {
				alert('Success');
			},

			getPhotos(photos) {
				/* let divTakePhotos = document.querySelector('#take-photos');

				divTakePhotos.remove(); */

				this.userInfo.images = photos;
			}
		}
    }
</script>

<style scoped>
	#registration {
		background-color: rgb(209, 231, 250);
	}

	.title {
		font-family: Verdana, sans-serif;
		color: white;
	}
</style>