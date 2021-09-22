<template>
  <div v-if="!isAuthenticated && !loading">
    <button id="qsLoginBtn" class="btn btn-primary btn-block" @click="login">
      Log in
    </button>
  </div>
</template>

<script>
/* eslint-disable @typescript-eslint/explicit-module-boundary-types */
import { inject } from 'vue';
export default {
  name: 'AppHeader',
  inject: ['Auth'],
  methods: {
    login() {
      this.Auth.loginWithRedirect();
    },
    logout() {
      this.Auth.logout();
      this.$router.push({ path: '/' });
    }
  },
  setup() {
    const auth = inject('Auth');
    return {
      ...auth
    };
  }
};
</script>

<style>
#mobileAuthNavBar {
  min-height: 125px;
  justify-content: space-between;
}
</style>
