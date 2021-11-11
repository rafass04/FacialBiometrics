import Vue from 'vue';
import App from './App.vue';
import VueMeta from 'vue-meta';

import router from './js/rotas';
import http from './js/http';

import {BootstrapVue, IconsPlugin} from 'bootstrap-vue';
import {WebCam} from 'vue-cam-vision';

import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap-vue/dist/bootstrap-vue.css';

Vue.use(BootstrapVue);
Vue.use(IconsPlugin);
Vue.use(VueMeta);

Vue.component(WebCam.name, WebCam);

Vue.config.productionTip = false;
Vue.prototype.$requisicao = http;

new Vue({
	router,
	render: h => h(App)
}).$mount("#app");