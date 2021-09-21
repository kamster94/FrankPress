<template>
  <q-card flat bordered class="article">
    <q-card-section>
      <div class="text-h6">{{ article.title }}</div>
    </q-card-section>

    <q-card-section class="q-pt-none">
      Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod
      tempor incididunt ut labore et dolore magna aliqua.
    </q-card-section>

    <q-separator inset />

    <q-card-section>
      Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod
      tempor incididunt ut labore et dolore magna aliqua.
    </q-card-section>
  </q-card>
</template>

<script lang="ts">
import { defineComponent, PropType } from 'vue';
import { Article } from './models';

export default defineComponent({
  name: 'ArticleContainer',
  props: {
    article: {
      type: Object as PropType<Article>,
      required: true,
    },
  },
});
</script>

<style lang="sass" scoped>
.article
  max-width: 70%
  margin-left: auto
  margin-right: auto
</style>
