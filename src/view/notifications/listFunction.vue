<template>
    <div>
        <div  class="" :class="{'Funtion' :!isShow}">
            <ul class="List">
                <li @click ="selectDelete()">Xoá</li>
                <li>Nhân Bản</li>
                <li>Gì đấy</li>
            </ul>
        </div>
    </div>
</template>
<style >
.Funtion{
    display: none;
}
.List{
    list-style-type: none;
    width: 60px;
    height: 60px;
    border: 1px solid #bbbbbb;
    position: absolute;
    top: 15px;
    left: 0;
    background-color: #ffffff;
    z-index: 100;
}
li{
    margin-top: 3px;
    position: relative;
    left: -31px;
}
li:hover {
    background-color: #f4f5f8;
    color:#2ca01c;
    
}
</style>
<script>
export default {

    created(){
    },
    props:{
        isShow : {type: Boolean, default: false},
        IdToDelete: {type : String, default: ""}
    },
    methods: {
        selectDelete(){
            this.$emit('hideListFuntion');
            console.log("đã ấn chọn xoá");
        }
    },
    watch : {
        check(){
            if(this.check.toString().length>0){
                this.isShow=true;
            }
        }
    }
}
</script>