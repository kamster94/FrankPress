<template>
  <q-btn
    flat
    @click="login"
    icon="manage_accounts"
    label="Log in"
    v-if="!isAuthenticated && !loading"
  />

  <q-btn
    flat
    icon="manage_accounts"
    label="Settings"
    v-if="isAuthenticated && !loading"
  >
    <q-menu>
      <div class="row no-wrap q-pa-md">
        <div class="column">
          <div class="text-h6 q-mb-md">Settings</div>
          <q-btn flat color="primary" label="Profile" />
          <q-btn flat color="primary" to="/admin" label="Administration" />
        </div>

        <q-separator vertical inset class="q-mx-lg" />

        <div class="column items-center">
          <q-avatar size="72px">
            <img src="https://cdn.quasar.dev/img/avatar4.jpg" />
          </q-avatar>

          <div class="text-subtitle1 q-mt-md q-mb-xs">John Doe</div>

          <q-btn
            flat
            color="primary"
            label="Logout"
            push
            size="sm"
            v-close-popup
            @click="logout()"
          />
        </div>
      </div>
    </q-menu>
  </q-btn>
</template>

<script>
import { inject, defineComponent } from 'vue';

export default defineComponent({
  name: 'AppHeaderLogin',
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
});
</script>
