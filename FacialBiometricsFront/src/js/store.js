import Vue from 'vue';
import Vuex from 'vuex';
import createPersistedState from 'vuex-persistedstate';
import http from './security';

Vue.use(Vuex);

const estado = {
    token: null,
    usuario: {}
}

const mutacoes = {
    USUARIO_LOGADO(state, {token, usuario}) {
        state.token = token
        state.usuario = usuario
    },

    DESLOGAR_USUARIO(state) {
        state.token = null
        state.usuario = {}
    }
}

const action = {
    /* {commit} é o contexto do Vuex */

    authentication({commit}, user) {
        return new Promise((resolve, reject) => {
            http.post('/auth', user)
                .then((response) => {
                    commit('USUARIO_LOGADO', {
                        token: response.data.token,
                        usuario: response.data.usuario
                    });

                    resolve(response.data);

                }).catch(exception => {
                    reject(exception);
                })
        })
    }
}

const getters = {
    usuarioLogado: state => Boolean(state.token)
};

export default new Vuex.Store({
    state: estado,
    mutations: mutacoes,
    actions: action,
    getters,
    plugins: [createPersistedState()]
});