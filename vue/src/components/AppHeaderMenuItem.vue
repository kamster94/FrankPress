<template>
  <q-route-tab
    :name="item.name"
    :to="item.route"
    :icon="item.icon"
    :label="item.label"
  />
</template>

<script lang="ts">
import { defineComponent, PropType } from 'vue';

export interface AppHeaderMenuItemProps {
  name: string;
  label: string;
  icon: string;
  route: string;
}

export default defineComponent({
  name: 'AppHeaderMenuItem',
  props: {
    item: {
      type: Object as PropType<AppHeaderMenuItemProps>,
      required: true
    }
  }
});
</script>
