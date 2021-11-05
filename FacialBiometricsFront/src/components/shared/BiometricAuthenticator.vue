<template>
    <div>
        <WebCam ref="webcam"></WebCam>
    </div>
</template>

<script>
    import {WebCam} from 'vue-cam-vision';

    export default {
        components: {
            WebCam
        },
    }
</script>

<style scoped></style>