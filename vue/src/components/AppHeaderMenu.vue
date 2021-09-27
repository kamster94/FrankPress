<template>
  <q-tabs inline-label>
    <app-header-menu-item
      v-for="item in menuItems"
      :key="item.name"
      :item="item"
    />
  </q-tabs>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import AppHeaderMenuItem, {
  AppHeaderMenuItemProps
} from '@/components/AppHeaderMenuItem.vue';

export default defineComponent({
  name: 'AppHeaderMenu',
  components: {
    AppHeaderMenuItem
  },
  data() {
    const menuItems: AppHeaderMenuItemProps[] = [
      {
        name: 'articles',
        label: 'Articles',
        icon: 'article',
        route: '/'
      },
      {
        name: 'categories',
        label: 'Categories',
        icon: 'category',
        route: '/categories'
      },
      {
        name: 'tags',
        label: 'Tags',
        icon: 'label',
        route: '/tags'
      },
      {
        name: 'authors',
        label: 'Authors',
        icon: 'people',
        route: '/authors'
      }
    ];
    return {
      menuItems
    };
  }
});
</script>

<style lang="sass" scoped>
.q-tab
  &::v-deep
    .q-tab__content
      flex-wrap: wrap !important

.q-tabs
  &::v-deep
    .q-tabs__content
      flex-wrap: wrap !important
</style>
