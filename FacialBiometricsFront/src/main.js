import Vue from 'vue';
import App from './App.vue';
import VueMeta from 'vue-meta';
import VueStepWizard from 'vue-step-wizard'

import store from './js/store';
import router from './js/rotas';
import http from './js/security';

import {BootstrapVue, IconsPlugin} from 'bootstrap-vue';
import {WebCam} from 'vue-cam-vision';

import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap-vue/dist/bootstrap-vue.css';
import 'vue-step-wizard/dist/vue-step-wizard.css';

Vue.use(BootstrapVue);
Vue.use(IconsPlugin);
Vue.use(VueMeta);
Vue.use(VueStepWizard);

Vue.component(WebCam.name, WebCam);

Vue.config.productionTip = false;
Vue.prototype.$requisicao = http;

new Vue({
	router,
	store: store,
	render: h => h(App)
}).$mount("#app");