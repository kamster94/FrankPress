<template>
  <q-header elevated>
    <q-toolbar class="bg-primary text-white rounded-borders">
      <q-btn
        v-if="isAdmin"
        round
        dense
        flat
        icon="menu"
        class="q-mr-xs"
        @click="toggleDrawer"
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
              />
            </div>
          </div>
        </q-menu>
      </q-btn>
    </q-toolbar>
  </q-header>
</template>

<script lang="ts">
import { defineComponent, ref } from 'vue';

export default defineComponent({
  name: 'AppHeader',
  props: {
    isAdmin: Boolean,
  },
  methods: {
    toggleDrawer() {
      this.$emit('toggle-drawer');
    },
  },
  setup() {
    return {
      searchText: ref(''),
    };
  },
});
</script>
