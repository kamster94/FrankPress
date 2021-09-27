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
import { defineComponent } from 'vue';
import AppHeader from '@/components/AppHeader.vue';
import AppFooter from '@/components/AppFooter.vue';

export default defineComponent({
  name: 'LayoutDefault',

  components: {
    AppHeader,
    AppFooter
  }
});
</script>
