<template>
    <div>    
        <div class="jumbotron content">
            <div class="container">
                <div class="row">
                    <img src="../assets/protecao-do-meio-ambiente.png" height="100%" alt="Meio Ambiente" class="img-fluid opacity" />
                            
                    <div class="col-md-6 mt-5 contents">
                        <div class="row justify-content-center">
                            <div class="col-md-8 border rounded">
                                <div class="text-center mb-4">
                                    <h3> Sign In </h3>
                                </div>

                                <form @submit.prevent.stop="auth">
                                    <div class="form-group first">
                                        <label for="username"> Username: </label>

                                        <div class="input-group">
                                            <div class="input-group-prepend">
                                                <div class="input-group-text">
                                                    <b-icon icon="person-fill"></b-icon>
                                                </div>
                                            </div>

                                            <input v-model="userInfo.username_user" type="text" class="form-control" id="username" placeholder="Username" />
                                        </div>
                                    </div>

                                    <div class="form-group last mb-4">
                                        <label for="password"> Password: </label>

                                        <div class="input-group">
                                            <div class="input-group-prepend">
                                                <div class="input-group-text">
                                                    <b-icon icon="lock-fill"></b-icon>
                                                </div>
                                            </div>

                                            <input v-model="userInfo.password_user" type="password" class="form-control" id="password" placeholder="Password" />
                                        </div>
                                    </div>

                                    <p v-show="errorMessage" class="container alert alert-danger text-center mt-3"> 
                                        {{errorMessage}} 
                                    </p>

                                    <div class="d-flex mb-5 align-items-center">
                                        <label class="control control--checkbox mb-0">
                                            <span class="caption">
                                                Remember me
                                            </span>

                                            <input type="checkbox" checked />

                                            <div class="control__indicator"></div>
                                        </label>

                                        <span class="ml-auto">
                                            <button type="button" v-b-modal.modal-1 class="btn btn-link">
                                                Forgot Password
                                            </button>
                                        </span>
                                    </div>

                                    <input type="submit" value="Log In" class="btn btn-block btn-primary mb-3" />
                                </form>

                                <b-modal id="modal-1" title="Forgot Password">
                                    <span>
                                        <small> Email: </small>

                                        <input type="email" class="form-control form-control-sm mt-2" placeholder="test@email.com" />
                                    </span>
                                </b-modal>

                                <div class="text-center">
                                    <span>
                                        Don't have an account? 
                                        
                                        <router-link :to="{name: 'registration'}">
                                            <button type="button" class="btn btn-link text-success"> 
                                                Register 
                                            </button>
                                        </router-link>
                                    </span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    export default {
        data() {
            return {
                userInfo: {
                    username_user: '',
                    password_user: ''
                },

                errorMessage: ''
            }
        },

        methods: {
            auth() {
                // this.$router.push({name: 'funcionarios'});

                let usuario = {
                    nome: this.userInfo.username_user,
                    senha: this.userInfo.password_user
                };

                this.$store.dispatch('authentication', usuario)
                    .then((response) => {
                        if(response.token) {
                            this.$router.push({name: 'biometrics'});
                        }
                    })
                    .catch((exception) => {
                        if(exception.request.status === 401) {
                            this.errorMessage = 'Username or password is invalid';
                        }
                    });
            }
        }
    }
</script>

<style scoped>
    .opacity {
        opacity: 0.7;
    }
</style>