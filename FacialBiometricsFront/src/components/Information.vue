<template>
    <div>
        <b-carousel
            id="carousel-1"
            :interval="4000"
            fade
            controls
            indicators
            img-width="800"
            img-height="300"
            style="text-shadow: 1px 1px 2px #333;"
        >  
            <b-carousel-slide v-for="(article, index) in listArticles" img-blank :key="article.id_article">
                <b-card :title="article.article_title" :img-src="images[index]" img-alt="Card image" img-left class="mb-3">
                    <b-card-text>
                        {{article.article_content}}
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
                listArticles: [
                    {id_article: 1, article_title: 'Amazônia', article_content: 'A floresta tropical amazônica, que cobre boa parte do noroeste do Brasil e se estende até a Colômbia, o Peru e outros países da América do Sul, é a maior floresta tropical do mundo, famosa por sua biodiversidade.', id_user_position: 1},
                    {id_article: 2, article_title: 'Mata Atlântica', article_content: 'A Mata Atlântica é um bioma de floresta tropical que abrange a costa leste, nordeste, sudeste e sul do Brasil, leste do Paraguai e a província de Misiones, na Argentina.', id_user_position: 2},
                    {id_article: 3, article_title: 'Pantanal', article_content: 'Complexo do Pantanal, ou simplesmente Pantanal, é um bioma constituído principalmente por uma savana estépica, alagada em sua maior parte, com 250 mil quilômetros quadrados de extensão, altitude média de 100 metros.', id_user_position: 2},
                    {id_article: 4, article_title: 'Pampa', article_content: 'Os pampas constituem uma região natural e pastoril de planícies com coxilhas cobertas por campos localizada no sul da América do Sul.', id_user_position: 3}
                ],

                images: [
                    'https://www.bioblog.com.br/wp-content/uploads/2017/03/a-importancia-da-preservacao-do-meio-ambiente.jpg',
                    'https://lh3.googleusercontent.com/proxy/CWWT5PPMzNCKeMTzq0Y7yNlKI9vxFdUjMOnfLUxt3ut6znCbZOoQnSMiCdsUqYPZAjxLerIkkAStkS5RXwgYj3_7rrtevMuSz3k51AE_1mIXE_g30mpE6nEDNOJ1Oe6x2ng0KTFYBVC3ORt32T65IXXKVA',
                    'https://www.gov.br/cgu/pt-br/governo-aberto/noticias/2017/principio-10-e-ogp-meio-ambiente-e-governo-aberto/sdf.jpg/@@images/238e2d55-636b-44e3-899c-4a79bdf1791e.jpeg',
                    'https://brasilsustentaveleditora.com.br/wp-content/uploads/2018/09/001.jpg'
                ]
            }
        },

        methods: {
            getArticles() {
                let user = JSON.parse(localStorage.getItem('user'));

                this.$requisicao.get('/user/articles', user.idUser)
                    .then((response) => {
                        this.listArticles = response.data;
                    })
            },

            getUserByLevel() {
                let user = JSON.parse(localStorage.getItem('user'));

                this.$requisicao.get('/user/articles', user.id_user_position)
                    .then((response) => {

                    })
            }
        },

        created() {
            //this.getUserByLevel();
            //this.getArticles();
        }
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