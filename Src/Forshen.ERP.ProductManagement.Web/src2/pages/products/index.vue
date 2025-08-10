<script setup lang="ts">
import { ref, onMounted } from 'vue'
import { Client, Product } from '~/lib/client/api-client'  // Adjust path to your generated client

const data = ref<Product[]>([])

// Create an instance of your client with base URL
const api = new Client('http://localhost:5000')

onMounted(async () => {
  try {
    // Replace `getData()` with your actual generated method name
    const response = await api.product()
    data.value = response  // or response.items or whatever your API returns
  } catch (error) {
    console.error('Failed to load data from API:', error)
  }
})

</script>

<template>
  werkt dit nu wel?
</template>
