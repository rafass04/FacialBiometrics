<template>
    <b-navbar toggleable="lg" type="dark" class="bg-nav">
        <b-navbar-brand> 
            <img src="../../assets/bandeira-brasil.png" width="55" height="55" /> Meio Ambiente 
        </b-navbar-brand>

        <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>

        <b-collapse id="nav-collapse" is-nav>
            <b-navbar-nav class="ml-auto">
                <b-nav-item-dropdown right>
                    <template #button-content>
                        <em>
                            <b-avatar variant="primary" size="sm"></b-avatar> {{username}}
                        </em>
                    </template>

                    <b-dropdown-item>
                        <b-icon icon="gear-fill" aria-hidden="true"></b-icon> Profile
                    </b-dropdown-item>

                    <b-dropdown-item @click="logout">
                        <b-icon icon="box-arrow-in-left" aria-hidden="true"></b-icon> Sign Out
                    </b-dropdown-item>
                </b-nav-item-dropdown>
            </b-navbar-nav>
        </b-collapse>
    </b-navbar>
</template>

<script>
    export default {
        data() {
            return {
                username: 'Test' /* JSON.parse(localStorage.getItem("user")).username */
            }
        },

        methods: {
            logout() {
                localStorage.removeItem('user');
                this.$router.push({name: 'login'});
            }
        }
    }
</script>

<style scoped>
    .bg-nav {
        background-color: #3CB371 !important;
    }

    .texto-verde {
        color: #057C71 !important;
    }

    .user {
        text-transform: capitalize;
    }
</style>