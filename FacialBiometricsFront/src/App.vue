<template>
	<div id="app">
		<div v-if="this.$router.history.current.path == '/information'">
			<Header />
		</div>

		<router-view></router-view>
	</div>
</template>

<script>
	import Header from './components/shared/Header.vue';
	import {mapGetters} from 'vuex';

	export default {
		name: 'app',

		components: {
			Header
		},

		metaInfo: {
      		title: 'Facial',

      		htmlAttrs: {
        		lang: 'pt-BR'
      		},

			meta: [
				{charset: 'utf-8'},
				{name: 'description', content: 'Aplicação para reconhecimento facial'},
				{name: 'viewport', content: 'width=device-width, initial-scale=1.0'}
			],

			link: [
				{rel: 'icon', href: require('./assets/vue-icon.png')}
			]
    	},

		computed: {
            ...mapGetters(['usuarioLogado'])
        }
	}
</script>

<style scoped></style>