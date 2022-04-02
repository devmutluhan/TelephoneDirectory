<template>
    <div id="CreateContact">
        <form action="" >
            <div class="addContact">
                <h3>Kişi Ekle</h3>
                <input type="text" v-model="fname" placeholder="İsim Soyisim Giriniz">
                <input type="text" v-model="mobileNumber" placeholder="Cep Telefon Numarası Giriniz">
                <input type="text" v-model="companyNumber" placeholder="İş Telefon Numarası Giriniz">
                <input type="text" v-model="homeNumber" placeholder="Ev Telefon Numarası Giriniz">
                <input type="text" v-model="address" placeholder="Adres Giriniz">
                <input type="text" v-model="email" placeholder="Email Giriniz">
                <button type="button" @click="addButton">Ekle</button>
            </div>
        </form>
    </div>
</template>


<script>

export default{
    name:'CreateContactForm',
    data(){
        return {
            fname:"",
            mobileNumber:"",
            companyNumber:"",
            homeNumber:"",
            address:"",
            email:""
        }
    },
    methods:{
        addButton: function(){
            fetch("http://localhost:5000/api/contact", {
            method:'POST',
            body: JSON.stringify({
                fullName : this.fname,
                mobileNumber : this.mobileNumber,
                companyNumber: this.companyNumber,
                homeNumber:this.homeNumber,
                address:this.address,
                email:this.email
            }),
            headers: { "Content-type": "application/json; charset=UTF-8" }
        }).then(window.location.reload())
        }
    }

}
</script>


<style>
.addContact{
    width: 30%;
    height: 420px;
    margin: 80px 500px;
    border: 1px solid gray;
}
.addContact input{
    width: 95%;
    margin: 10px 2px 10px 2px;
    padding: 5px;
}
.addContact button{
    padding: 15px 40px;
}
</style>