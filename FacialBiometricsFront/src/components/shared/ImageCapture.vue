<template>
    <div>
        <div class="row">
            <div>
                <WebCam
                    class="justify-content-center ml-3"
                    ref="webcam"
                    :height="300"
                    @error="getError"
                ></WebCam>
            </div>
        </div>

        <div class="mt-2">
            <input type="checkbox" class="ml-4" id="checkbox-image-1" name="photo-1" /> Photo 1

            <input type="checkbox" class="ml-4" id="checkbox-image-2" name="photo-2" /> Photo 2

            <input type="checkbox" class="ml-4" id="checkbox-image-3" name="photo-3" /> Photo 3
        </div>

        <div class="mt-4 mb-5">
            <b-button :disabled="hasThreeImages" @click="capturePhoto" variant="dark"> 
                Capture
            </b-button>
        </div>
    </div>
</template>

<script>
    import {WebCam} from 'vue-cam-vision';

    export default {
        components: {
            WebCam
        },

        data() {
            return {
                captures: [],
                i: 1
            }
        },

        methods: {
            capturePhoto() {
                let capture = this.$refs.webcam.capture();

                capture
                    .then((base64) => {
                        this.captures.push(base64);

                        let checkbox = document.querySelector(`#checkbox-image-${this.i}`);

                        checkbox.checked = true;

                        this.i++;

                        if(this.i == 4) {
                            this.$emit('photos-list', this.captures);
                        }
                    })
                    .catch((exception) => {
                        alert('There was an error when taking the photo. Try again');

                        console.log(`Error -> ${exception}`);
                    })
            },

            getError(error) {
                alert('An error has occurred!!! \nCheck that you have connected to your camera');

                console.log(error);
            }
        },

        computed: {
			hasThreeImages() {
				return this.captures.length == 3;
			}
		}
    }
</script>

<style scoped>
    #captured-image {
        object-fit: cover; /* Redimensiona a imagem para caber na div */
    }
</style>