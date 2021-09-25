<template>
  <div class="header-wrapper">
    <div class="header-block center">
      <h1>FrankPress</h1>
    </div>
    <div v-if="!isAuthenticated && !loading" class="header-block right">
      <el-button
        type="primary"
        @click="login"
        icon="el-icon-user"
        title="Log in"
        >Log in</el-button
      >
    </div>
  </div>
  <el-menu router class="el-menu-demo" mode="horizontal">
    <el-menu-item index="1" route="/">Home</el-menu-item>
    <el-menu-item index="2" route="/categories">Categories</el-menu-item>
    <el-menu-item index="3" route="/tags">Tags</el-menu-item>
  </el-menu>
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

<style lang="scss" scoped>
.left {
  text-align: left;
}
.right {
  text-align: right;
}
.center {
  text-align: center;
}
.header-wrapper {
  display: flex;
  flex-flow: row wrap;
  justify-content: space-between;
}
</style>
