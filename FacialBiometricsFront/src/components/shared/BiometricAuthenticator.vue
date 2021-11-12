<template>
    <b-container>
        <b-overlay :variant="variant" :opacity="opacity"  :show="exibeOverlay" rounded="sm">
            <div class="row mt-2 justify-content-center">
                <div class="col-6 rounded text-center">
                    <h3 class="title mt-1 heading"> Recognition Face </h3>                 
                </div>
            </div>

            <div class="row mt-2 justify-content-center">
                <div id="containerCam" class="col-6">
                    <WebCam border width="100%" height="100%" id="camera" ref="webcam"></WebCam>

                    <h6 class="text-center">center your face</h6>
                </div>      
            </div>

            <div class="row">
                <div class="col-12 text-center pb-2">
					<p v-show="errorMessage" class="alert alert-danger text-center mt-3"> 
                        {{errorMessage}}
                    </p>

                	<b-button @click.prevent="capture">Capture & Send</b-button>
                </div>    
            </div> 
        </b-overlay>
    </b-container>
</template>

<script>
    import {WebCam} from 'vue-cam-vision';

    export default {
        components: {
            WebCam
        },

        data() {
            return {
                variant: 'dark',
                opacity: 0.85,

                show: false,
                image: [],

                userImageInfo: {
                    idUser: 0,
                    image: []
                },

				errorMessage: ''
            }
        },

        computed: {
            exibeOverlay: function() {
                return this.show;
            }
        },

        methods: {
        	capture() {
            	let capture = this.$refs.webcam.capture();

              	capture.then(base64 => {
                	this.userImageInfo.image.splice(0)
                  	this.userImageInfo.image.push(base64)[0]
					this.sendImage();
					
              	}).catch((e) => {
                  	alert(`Erro: ${e}`)
              	})
          },  

			sendImage() {
				this.show = true;
				
                var user = JSON.parse(localStorage.getItem("user"));
                this.userImageInfo.idUser = user.idUser;

                this.$requisicao.post('/user/validate', this.userImageInfo)
                    .then(response => {
                        console.log(response.data.statusCode);

                        if(response.data.statusCode == 401) {
							this.show = false;
                            this.errorMessage = 'Invalid Biometric data';
                        }

                        if(response.data.statusCode == 200) {
							this.$router.push({name: 'information'});
						}
                    })
                    .catch(exception => {                        
                        console.log(exception)
                    })
        	} 
        }
    }
</script>

<style scoped>
    .container {
        height: 100%;
    }

    #camera {
        border-radius: 20px;
        overflow: hidden;
        position: relative;
    }

    .heading {
        color: #094609;
    }

    .container {
        padding: 0px;
        margin-top: 5px;
        margin-bottom: 5px;
        border: 0.5px solid #094609;
        border-radius: 10px;
    }
</style>