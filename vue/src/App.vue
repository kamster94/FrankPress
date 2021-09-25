<template>
  <el-container>
    <el-header height="140px">
      <app-header />
    </el-header>
    <el-container>
      <el-aside width="200px" v-if="isAuthenticated && !loading">
        <app-aside />
      </el-aside>
      <el-main>
        <router-view />
      </el-main>
    </el-container>
    <el-footer>
      <app-footer />
    </el-footer>
  </el-container>
</template>

<script>
/* eslint-disable @typescript-eslint/explicit-module-boundary-types */
import { inject } from 'vue';
import AppHeader from '@/components/AppHeader';
import AppFooter from '@/components/AppFooter.vue';
import AppAside from './components/AppAside.vue';

export default {
  components: {
    AppHeader,
    AppFooter,
    AppAside
  },
  inject: ['Auth'],
  methods: {
    setup() {
      const auth = inject('Auth');
      return {
        ...auth
      };
    }
  }
};
</script>

<style lang="scss">
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

#nav {
  padding: 30px;

  a {
    font-weight: bold;
    color: #2c3e50;

    &.router-link-exact-active {
      color: #42b983;
    }
  }
}
</style>
