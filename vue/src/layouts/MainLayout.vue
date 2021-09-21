<template>
  <q-layout view="hHh Lpr fFf">
    <app-header />

    <q-page-container>
      <router-view />
    </q-page-container>

    <app-footer />
  </q-layout>
</template>

<script lang="ts">
import AppFooter from 'src/components/AppFooter.vue';
import AppHeader from 'src/components/AppHeader.vue';
import { defineComponent, ref } from 'vue';

export default defineComponent({
  name: 'MainLayout',
  components: {
    AppHeader,
    AppFooter,
  },

  setup() {
    return {
      text: ref(''),
    };
  },
});
</script>
