<template>
  <q-item active clickable v-ripple :to="item.route">
    <q-item-section avatar>
      <q-icon :name="item.icon" />
    </q-item-section>

    <q-item-section>
      <q-item-label>{{ item.label }}</q-item-label>
      <q-item-label caption>{{ item.caption }}t</q-item-label>
    </q-item-section>
  </q-item>
</template>

<script lang="ts">
import { defineComponent, PropType } from 'vue';

export interface AdminMenuItemProps {
  label: string;
  caption: string;
  icon: string;
  route: string;
}

export default defineComponent({
  name: 'AdminMenuItem',
  props: {
    item: {
      type: Object as PropType<AdminMenuItemProps>,
      required: true
    }
  }
});
</script>
