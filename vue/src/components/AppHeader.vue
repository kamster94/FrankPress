<template>
  <q-header elevated>
    <q-toolbar class="bg-primary text-white rounded-borders">
      <q-btn
        v-if="$q.screen.xs"
        flat
        round
        dense
        icon="menu"
        @click="drawerVisible = !drawerVisible"
      />
      <q-toolbar-title
        ><strong>FrankPress</strong> / Simple CMS</q-toolbar-title
      >

      <q-input
        dark
        dense
        standout
        v-model="searchText"
        input-class="text-right"
        class="q-ml-md"
      >
        <template v-slot:append>
          <q-icon v-if="searchText === ''" name="search" />
          <q-icon
            v-else
            name="clear"
            class="cursor-pointer"
            @click="searchText = ''"
          />
        </template>
      </q-input>
    </q-toolbar>

    <q-toolbar class="bg-primary text-white rounded-borders">
      <app-header-menu />

      <q-space />

      <app-header-login />
    </q-toolbar>
  </q-header>

  <q-drawer
    v-if="isAdmin"
    v-model="drawerVisible"
    show-if-above
    :mini="miniState"
    :width="300"
    :breakpoint="500"
    bordered
    class="bg-grey-3"
  >
    <admin-menu
      @toggled-mini-state="miniState = !miniState"
      :miniState="miniState"
    />
  </q-drawer>
</template>

<script>
import { inject, defineComponent, ref } from 'vue';
import AdminMenu from '@/components/AdminMenu.vue';
import AppHeaderLogin from '@/components/AppHeaderLogin.vue';
import AppHeaderMenu from '@/components/AppHeaderMenu.vue';

export default defineComponent({
  name: 'AppHeader',
  components: {
    AdminMenu,
    AppHeaderLogin,
    AppHeaderMenu
  },
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
  computed: {
    isAdmin() {
      return this.$route.path.match('/admin*');
    }
  },
  setup() {
    const miniState = ref(false);
    const auth = inject('Auth');
    return {
      ...auth,
      searchText: ref(''),
      drawerVisible: ref(false),
      miniState
    };
  }
});
</script>
