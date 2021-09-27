<template>
  <q-scroll-area class="fit">
    <q-list padding>
      <q-item
        clickable
        v-ripple
        @click="emitToggledMiniState()"
        v-if="$q.screen.gt.xs"
      >
        <q-item-section avatar>
          <q-icon :name="miniIcon()" />
        </q-item-section>

        <q-item-section> Collapse </q-item-section>
      </q-item>

      <q-separator v-if="$q.screen.gt.xs" />

      <admin-menu-item
        v-for="item in adminMenuItems"
        :key="item.caption"
        :item="item"
      ></admin-menu-item>
    </q-list>
  </q-scroll-area>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import AdminMenuItem, {
  AdminMenuItemProps
} from '@/components/AdminMenuItem.vue';

export default defineComponent({
  name: 'AdminMenu',
  components: {
    AdminMenuItem
  },
  emits: ['toggledMiniState'],
  props: {
    miniState: {
      type: Boolean
    }
  },
  data() {
    const adminMenuItems: AdminMenuItemProps[] = [
      {
        label: 'Dashboard',
        caption: 'Main administration panel',
        icon: 'dashboard',
        route: '/admin'
      },
      {
        label: 'Articles',
        caption: 'Articles management',
        icon: 'article',
        route: '/admin/articles'
      },
      {
        label: 'Categories',
        caption: 'Categories management',
        icon: 'category',
        route: '/admin/categories'
      },
      {
        label: 'Tags',
        caption: 'Tags management',
        icon: 'label',
        route: '/admin/tags'
      },
      {
        label: 'Media',
        caption: 'Media management',
        icon: 'photo_library',
        route: '/admin/media'
      },
      {
        label: 'Users',
        caption: 'Users management',
        icon: 'group',
        route: '/admin/users'
      }
    ];
    return {
      adminMenuItems
    };
  },
  methods: {
    emitToggledMiniState() {
      this.$emit('toggledMiniState');
    }
  },
  setup(props) {
    return {
      miniIcon() {
        if (props.miniState === true) {
          return 'chevron_right';
        } else {
          return 'chevron_left';
        }
      }
    };
  }
});
</script>
