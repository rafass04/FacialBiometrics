import Vue from 'vue';
import VueRouter from 'vue-router';

import Login from '../components/Login.vue';
import Information from '../components/Information.vue';
import Registration from '../components/Registration.vue';
import BiometricAuthenticator from '../components/shared/BiometricAuthenticator.vue';

import store from './store';

Vue.use(VueRouter);

const routes = [
    {
        path: '/', 
        component: Login,
        name: 'login',
        meta: {
            public: true
        }
    },
    {
        path: '/information', 
        component: Information,
        name: 'information',
        meta: {
            public: false
        }
    },
    {
        path: '/registration', 
        component: Registration,
        name: 'registration',
        meta: {
            public: true
        }
    },
    {
        path: '/biometric-authenticator', 
        component: BiometricAuthenticator,
        name: 'biometric-authenticator',
        meta: {
            public: true
        }
    }
];

const router = new VueRouter({
	routes,
    mode: 'history'
});

router.beforeEach((routeTo, routeFrom, next) => {
    if(!routeTo.meta.public && !store.state.token) {
        return next({path: '/'});
    }

    next();
});

export default router;