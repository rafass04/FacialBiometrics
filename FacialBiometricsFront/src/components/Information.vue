<template>
    <div>
        <b-carousel
            id="carousel-1"
            v-model="slide"
            :interval="4000"
            fade
            controls
            indicators
            img-width="800"
            img-height="300"
            style="text-shadow: 1px 1px 2px #333;"
        >  
            <b-carousel-slide v-for="(slide, index) in slides" img-blank :key="index">
                <b-card :title="slide.cargo" :img-src="slide.image" img-alt="Card image" img-left class="mb-3">
                    <b-card-text>
                        {{ slide.texto }}
                    </b-card-text>
                </b-card>
            </b-carousel-slide>
        </b-carousel>
    </div>
</template>

<script>
    export default {
        data() {
            return {
                slides: [
                    { cargo: "Ministro", image: 'https://cdn.pixabay.com/photo/2021/09/15/12/52/animal-6626792_960_720.jpg', texto: 'ascascasc'},
                    { cargo: "Gerente", image: 'https://cdn.pixabay.com/photo/2021/09/28/14/39/horse-6664660_960_720.jpg', texto: 'ascascascascascac'},
                    { cargo: "Funcionário", image: 'https://pixabay.com/pt/photos/areia-sobremesa-duna-sahara-6591629/', texto: 'dvsvsds sdv sdvsd vs vsv sd vsv sdv sdv svd sdv '},
                    { cargo: "Subordinado", image: 'https://image.flaticon.com/icons/png/512/1229/1229730.png', texto: ' sdv sdv sdv sdvs dvd f fg fsfwethrge gerg er gerger g'},
                ]
            }
        },
        
    }
</script>

<style scoped>
    h4 {
        color: black;
    }

    img {
        width: 300px;
        height: 300px;
    }

    p {
        color: green;
    }
</style>