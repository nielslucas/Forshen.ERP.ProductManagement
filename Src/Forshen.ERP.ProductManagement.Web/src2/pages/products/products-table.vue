<script setup lang="ts">
import {onMounted, ref} from "vue";
import {Client, Product} from "~/lib/client/api-client";

// Create an instance of your client with base URL
const api = new Client('http://localhost:5000')

const columns = [
  {
    name: 'Id',
    required: true,
    label: 'Id',
    align: 'left',
    field: 'id',
    // format: val => `${val}`,
    sortable: true
  },
  { name: 'Name', 
    align: 'left', 
    label: 'Name',
    field: 'name',
    sortable: true 
  },
]

const rows = ref<Product[]>([
  new Product({
    id: 1,
    name: 'Test',
    createdAt: new Date(),
    updatedAt: new Date(),
  })
])

const filter = ref('')
const loading = ref(false)
const pagination = ref({
  sortBy: 'id',
  descending: false,
  page: 1,
  rowsPerPage: 5,
  rowsNumber: 0
})

async function onRequest (props) {
  const { page, rowsPerPage, sortBy, descending } = props.pagination
  // const filter = props.filter

  loading.value = true
  const response = await api.productOverview(page, rowsPerPage, sortBy, descending);
  rows.value = response.pageItems ?? [];
  pagination.value.rowsNumber = response.totalItemsCount ?? 0;
  pagination.value.page = page
  pagination.value.rowsPerPage = rowsPerPage
  pagination.value.sortBy = sortBy
  pagination.value.descending = descending
  loading.value = false;
  return

  // clear out existing data and add new
  // rows.value.splice(0, rows.value.length, ...returnedData)
}

onMounted(async () => {
  loading.value = true
  const response = await api.productOverview(pagination.value.page, pagination.value.rowsPerPage, pagination.value.sortBy, pagination.value.descending);
  rows.value = response.pageItems ?? [];
  pagination.value.rowsNumber = response.totalItemsCount ?? 0;
  loading.value = false;

  const el = document.querySelector('main') // find the element
  if (el) {
    const height = (el as HTMLElement).offsetHeight
    document.documentElement.style.setProperty('--main-height', `${height}px`)
  }
})

</script>

<template>
  <q-table
      class="product-overview-table"
      title="Products"
      :columns="columns"
      :rows="rows"
      row-key="name"
      v-model:pagination="pagination"
      :loading="loading"
      :filter="filter"
      @request="onRequest"
      virtual-scroll
  />
</template>

<style lang="scss" scoped>
  .product-overview-table {
    height: calc(var(--main-height) - 50px);
  }
</style>