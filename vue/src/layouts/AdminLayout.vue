<template>
  <q-layout view="hHh Lpr fFf">
    <app-header isAdmin @toggle-drawer="toggleLeftDrawer" />

    <q-drawer v-model="leftDrawerOpen" side="left" show-if-above bordered>
      <q-list>
        <q-item-label header> Administration panels </q-item-label>

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

    <app-footer />
  </q-layout>
</template>

<script lang="ts">
import AppFooter from 'src/components/AppFooter.vue';
import AppHeader from 'src/components/AppHeader.vue';
import SidemenuLink from 'src/components/SidemenuLink.vue';

const adminLinksList = [
  {
    title: 'Dashboard',
    caption: 'Main administration panel',
    icon: 'dashboard',
    link: '/admin',
  },
  {
    title: 'Articles',
    caption: 'Articles management',
    icon: 'article',
    link: '/admin/articles',
  },
  {
    title: 'Categories',
    caption: 'Categories management',
    icon: 'category',
    link: '/admin/categories',
  },
  {
    title: 'Tags',
    caption: 'Tags management',
    icon: 'label',
    link: '/admin/tags',
  },
  {
    title: 'Media',
    caption: 'Media management',
    icon: 'photo_library',
    link: '/admin/media',
  },
  {
    title: 'Users',
    caption: 'Users management',
    icon: 'group',
    link: '/admin/users',
  },
];

import { defineComponent, ref } from 'vue';

export default defineComponent({
  name: 'AdminLayout',

  components: {
    SidemenuLink,
    AppHeader,
    AppFooter,
  },

  setup() {
    const leftDrawerOpen = ref(false);

    return {
      sidemenuLinks: adminLinksList,
      leftDrawerOpen,
      toggleLeftDrawer() {
        leftDrawerOpen.value = !leftDrawerOpen.value;
      },
      text: ref(''),
    };
  },
});
</script>
