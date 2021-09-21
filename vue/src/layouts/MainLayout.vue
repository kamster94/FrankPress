<template>
  <q-layout view="hHh Lpr fFf">
    <q-header elevated>
      <q-toolbar class="bg-primary text-white rounded-borders">
        <q-btn
          round
          dense
          flat
          icon="menu"
          class="q-mr-xs"
          @click="toggleLeftDrawer"
        />

        <q-toolbar-title
          ><strong>FrankPress</strong> / Simple CMS</q-toolbar-title
        >

        <q-input
          dark
          dense
          standout
          v-model="text"
          input-class="text-right"
          class="q-ml-md"
        >
          <template v-slot:append>
            <q-icon v-if="text === ''" name="search" />
            <q-icon
              v-else
              name="clear"
              class="cursor-pointer"
              @click="text = ''"
            />
          </template>
        </q-input>
      </q-toolbar>
      <q-toolbar class="bg-primary text-white rounded-borders">
        <q-btn-group outline>
          <q-btn to="/" label="Home" flat icon="home" />
          <q-btn to="/" label="Menu 2" flat icon="info" />
          <q-btn to="/" label="Menu 3" flat icon="grade" />
        </q-btn-group>

        <q-space />

        <q-btn flat icon="manage_accounts" label="Settings">
          <q-menu>
            <div class="row no-wrap q-pa-md">
              <div class="column">
                <div class="text-h6 q-mb-md">Settings</div>
                <q-btn flat color="primary" label="Profile" />
                <q-btn flat color="primary" label="Administration" />
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
                />
              </div>
            </div>
          </q-menu>
        </q-btn>
      </q-toolbar>
    </q-header>

    <q-drawer v-model="leftDrawerOpen" side="left" show-if-above bordered>
      <q-list>
        <q-item-label header> Submenu </q-item-label>

        <sidemenu-link
          v-for="link in sidemenuLinks"
          :key="link.title"
          v-bind="link"
        ></sidemenu-link>
      </q-list>
    </q-drawer>

    <q-page-container>
      <router-view />
    </q-page-container>

    <q-footer class="bg-grey-8 text-white">
      <q-toolbar>
        <div class="text-weight-light">Footer notes &copy; 2021</div>
      </q-toolbar>
    </q-footer>
  </q-layout>
</template>

<script lang="ts">
import SidemenuLink from 'src/components/SidemenuLink.vue';

const linksList = [
  {
    title: 'Home',
    caption: 'Home page with newest articles',
    icon: 'home',
    link: '/',
  },
];

import { defineComponent, ref } from 'vue';

export default defineComponent({
  name: 'MainLayout',

  components: {
    SidemenuLink,
  },

  setup() {
    const leftDrawerOpen = ref(false);

    return {
      sidemenuLinks: linksList,
      leftDrawerOpen,
      toggleLeftDrawer() {
        leftDrawerOpen.value = !leftDrawerOpen.value;
      },
      text: ref(''),
    };
  },
});
</script>
