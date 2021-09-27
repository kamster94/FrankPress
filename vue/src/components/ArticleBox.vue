<template>
  <q-card flat bordered class="article">
    <q-card-section>
      <div class="text-h6">{{ article.Title }}</div>
    </q-card-section>

    <q-card-section>
      {{ article.Content }}
    </q-card-section>
  </q-card>
</template>

<script lang="ts">
import { Article } from '@/models';
import { defineComponent, PropType } from 'vue';

export default defineComponent({
  name: 'ArticleBox',
  props: {
    article: {
      type: Object as PropType<Article>,
      required: true
    }
  }
});
</script>

<style lang="sass" scoped>
.article
  max-width: 50em
  margin-left: auto
  margin-right: auto
</style>
