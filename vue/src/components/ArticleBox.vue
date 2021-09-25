<template>
  <el-card class="article-box">
    <template #header>
      <div class="card-header">
        <span> {{ article.Title }} </span>
      </div>
    </template>
    <div class="text item">{{ article.Content }}</div>
  </el-card>
</template>

<script lang="ts">
import { Article } from '@/models';
import { PropType } from 'vue';

export default {
  name: 'ArticleBox',
  props: {
    article: {
      type: Object as PropType<Article>,
      required: true
    }
  }
};
</script>

<style lang="scss" scoped>
.article-box {
  max-width: 70%;
  margin-left: auto;
  margin-right: auto;
}
</style>
