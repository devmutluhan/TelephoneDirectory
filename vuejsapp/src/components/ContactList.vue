<template>
    <div id="ContactList">
        <div class="getContacts" v-if="page=='List'">
            <ul>
                <li v-for="user in users" 
                    v-bind:key="user"
                    @click="getData(user.contactId)">
                    <strong>{{user.fullName.toUpperCase()}} </strong> 
                </li>
            </ul>
        </div>
        <div class="getContact" v-if="page=='Get'">
            <button @click="homePage">Kişiler</button>
            <ul>
                <li>
                    <span @click="deleteData(id)">✖</span> 
                    <span @click="updateData(id)">✎</span><br>
                    <strong>{{fname.toUpperCase()}} </strong> <br><br>
                    <strong>Cep No:</strong>{{mobileNumber}}   <br><br>
                    <strong>İş No:</strong>{{companyNumber}} <br><br>
                    <strong>Ev No:</strong>{{homeNumber}} <br><br>
                    <strong>Adres:</strong>{{address}}<br><br>
                    <strong>Email:</strong>{{email}}
                </li>
            </ul>
        </div>
        <div class="putContact" v-if="page=='Put'">
            <h3>Kişi Düzenle</h3>
            <input type="text" v-model="fname" placeholder="İsim Soyisim Giriniz">
            <input type="text" v-model="mobileNumber" placeholder="Cep Telefon Numarası Giriniz">
            <input type="text" v-model="companyNumber" placeholder="İş Telefon Numarası Giriniz">
            <input type="text" v-model="homeNumber" placeholder="Ev Telefon Numarası Giriniz">
            <input type="text" v-model="address" placeholder="Adres Giriniz">
            <input type="text" v-model="email" placeholder="Email Giriniz">
            <button type="button" @click="putButton(id)">Düzenle</button>
        </div>
    </div>
</template>


<script>

export default{
    name: "ContactListVue",
    data() {
        return {
            users: {},
            page:"List",
            id:0,
            fname:"",
            mobileNumber:"",
            companyNumber:"",
            homeNumber:"",
            address:"",
            email:"",
        };
    },
    async mounted() {
        var response = await fetch("http://localhost:5000/api/contact");
        const data = await response.json();
        this.users = data;
    },
    methods: {
        deleteData: function (id) {
            fetch(`http://localhost:5000/api/contact/${id}`, {
                method: "DELETE"
            }).then(window.location.reload());
        },
        getData: function(id){
            fetch(`http://localhost:5000/api/contact/${id}`, {
                method: "GET"
            }).then(response => response.json())
            .then(res=> {
                this.page="Get"
                this.fname=res.fullName
                this.mobileNumber=res.mobileNumber
                this.companyNumber=res.companyNumber
                this.homeNumber=res.homeNumber
                this.address=res.address
                this.email=res.email
                this.id=res.contactId
            })
        },
        updateData: function (id) {
            this.page='Put'
            fetch(`http://localhost:5000/api/contact/${id}`, {
                method: "GET"
            }).then(response => response.json())
            .then(res => {
                this.fname=res.fullName
                this.mobileNumber=res.mobileNumber
                this.companyNumber=res.companyNumber
                this.homeNumber=res.homeNumber
                this.id=res.contactId
            });
        },
        putButton: function(id){
            var myHeaders = new Headers();
            myHeaders.append("Content-Type", "application/json");
            fetch(`http://localhost:5000/api/contact/${id}`, {
                method: "PUT",
                body: JSON.stringify({
                    "fullName": this.fname,
                    "mobileNumber": this.mobileNumber,
                    "companyNumber": this.companyNumber,
                    "homeNumber": this.homeNumber,
                    "address":this.address,
                    "email":this.email
                }),
                headers: myHeaders,
                redirect: "follow"
            }).then(window.location.reload())
        },
        homePage: function(){
            this.page="List"
        }
    }
}
</script>


<style>
.getContacts{
    width: 30%;
    margin-left:35%;
    margin-top: 60px ;
}
.getContacts ul li{
    list-style-type: none;
    width: 85%;
    height: 25px;
    float: left;
    text-align: left;
    margin: 5px;
    cursor: pointer;
    background-color: beige;
}
.getContacts li:hover{
    background-color: bisque;
}
.getContact span{
    float: right;
    margin:0 3px 0 3px;
    cursor:pointer;
}
.getContact span:hover{
    background-color:orange;
}
.getContact{
    width: 20%;
    margin-left:40%;
    margin-top: 60px ;
}
.getContact ul li{
    list-style-type: none;
    height: 20px;
    text-align: left;
}
.putContact{
    width: 30%;
    height: 410px;
    margin: 80px 500px;
    border: 1px solid gray;
}
.putContact input{
    width: 95%;
    margin: 10px 2px 10px 2px;
    padding: 5px;
}
.putContact button{
    padding: 15px 40px;
}
</style>