<template>
  <div id="app">
    <button @click="getPage">{{buttonName}}</button>
    
    <div v-if="page=='HomePage'">
      <ContactList/>
    </div>
    
    <div v-if="page=='AddPage'">
      <CreateContactForm/>
    </div>
  </div>
</template>

<script>
import CreateContactForm from './components/CreateContactForm.vue'
import ContactList from "./components/ContactList.vue";

export default {
  name: 'App',
  data(){
    return {
      user:{},
      page:"HomePage",
      buttonName:"Kişi Ekleme Sayfası"
      }
  },
  components: {
    CreateContactForm,
    ContactList
  },
  
  methods:{
    getPage: function(){
      if(this.page=="HomePage"){
        this.page="AddPage"
        this.buttonName="Kişiler Sayfası"
      }
      else if(this.page == "AddPage"){
        this.page="HomePage"
        this.buttonName="Kişi Ekleme Sayfası"
      }
    }
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
#app button{
  width: 180px;
  height: 40px;
}
</style>
