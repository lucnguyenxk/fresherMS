<template>
    <div>
        <div class="" :class="{'Dialog-In4':!isShow }" id= "Dialog" >
                <div class="Model">
                    <div class="Dialog-content">
                        <div class= "Dialog-Header">
                            <div class="header-title">THÔNG TIN NHÂN VIÊN</div>
                            <button class="close-diacontent" @click="CloDiaOnClick()">&#x2715;</button>
                        </div>
                        <div class="Dialog-Body">
                            <div class="Dialog_Body_top">
                                <div class="BodyTop_Left">
                                    <div class="Code_Name">
                                        <div class="Code_Emp">
                                            <p>Mã nhân viên <span>*</span></p>
                                            <input type="text" class="CodeEmp" ref ="employeeCodeFocus" v-model="employee.employeeCode">
                                        </div>
                                        <div class="Name_Emp">
                                            <p>Tên nhân viên <span>*</span></p> 
                                            <input type="text" @mouseover="MouseOverName()" @mouseout="MouseOutName()" class="NameEmp" :class="{'MissingValue':isMissingNameEmp}" v-model="employee.fullname">
                                            <p class="noti" :class="{'missing':!isMissingNameEmp}" >Tên không được trống!</p>
                                        </div>
                                    </div>
                                    <div class="Group_Emp">
                                        <p>Đơn vị <span>*</span></p>
                                        <select name="" id="Group" @mouseover="MouseOverGroup()" @mouseout="MouseOutGroup()" v-model="employee.departmentId" class="" :class="{ 'MissingValue':isMissingEmployeeDepartment}">
                                            <option value="7c4f14d8-66fb-14ae-198f-6354f958f4c0">Phòng nhân sự</option>
                                            <option value="45ac3d26-18f2-18a9-3031-644313fbb055">Phòng đào tạo</option>
                                            <option value="3f8e6896-4c7d-15f5-a018-75d8bd200d7c">Phòng hành chính</option>
                                            <option value="78aafe4a-67a7-2076-3bf3-eb0223d0a4f7">Phòng Marketing</option>
                                        </select>
                                        <p class="noti" :class="{'missing':!isMissingEmployeeDepartment}" >Tên đơn vị không được trống!</p>
                                    </div>
                                    <div class="Position_Emp"> 
                                        <p>Chức danh</p>
                                        <input type="text" class="PosEmp" v-model="employee.position">
                                    </div>
                                </div>
                                <div class="BodyTop_Right">
                                    <div class="DOB_GEN">
                                        <div class="DOBEmp">
                                            <p>Ngày sinh</p>
                                            <input type="date" class="DOB" v-model="employee.dateOfBirth">
                                        </div>
                                        <div class="GENEmp">
                                            <p>Giới tính</p>
                                            <div class="GenRadio">
                                                <input type="radio" id="male" name="gender" value="1" v-model="employee.gender">
                                                <label for="male">Nam</label><br>
                                                <input type="radio" id="female" name="gender" value="0" v-model="employee.gender">
                                                <label for="female">Nữ</label><br>
                                                <input type="radio" id="other" name="gender" value="2" v-model="employee.gender">
                                                <label for="other">Khác</label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="CMND_Emp">
                                        <div class="CMNDNum">
                                            <p>Số CMND</p>
                                            <input type="text" class="CMND" v-model="employee.identityCardNumber">
                                        </div>
                                        <div class="DateRange">
                                            <p>Ngày cấp</p>
                                            <input type="date" class="dateofRange">
                                        </div>
                                    </div>
                                    <div class="Place_range">
                                        <p>Nơi cấp</p>
                                        <input type="text" class="placeRange">
                                    </div>
                                </div>
                            </div>
                            <div class="Dialog_Body_bottom">
                                <div class="Address">
                                    <p>Địa chỉ</p>
                                    <input type="text" class="addressEmp" v-model="employee.address">
                                </div>
                                <div class="other_infor top">
                                    <div class="PhoneNumber">
                                        <p>Số điện thoại</p>
                                        <input type="text" class="PhoneNumberEmp" v-model="employee.phoneNumber">
                                    </div>
                                    <div class="PhoneNumberfixed need">
                                        <p>Số điện thoại cố định</p>
                                        <input type="text" class="PhoneNumberfixedEmp">
                                    </div>
                                    <div class="Email need">
                                        <p>Email</p>
                                        <input type="text" class="EmailEmp" v-model="employee.email">
                                    </div>
                                </div>
                                <div class="other_infor bottom">
                                    <div class="TkBank">
                                        <p>Tài khoản ngân hàng</p>
                                        <input type="text" class="TkBankEmp" v-model="employee.bankAccountNumber">
                                    </div>
                                    <div class="NameBank need">
                                        <p>Tên ngân hàng</p>
                                        <input type="text" class="NameBankEmp" v-model="employee.bankName">
                                    </div>
                                    <div class="BankBranch need">
                                        <p>Chi nhánh</p>
                                        <input type="text" class="BankBranchEmp">
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="Dialog-footer">
                            <button class="btn-cancel" id="" @click="CancelDialog()">Huỷ</button>
                            <button class="btn-cancel add" @click="AddOnClick()" id="">Lưu</button>
                            <button class="btn-save_and_add" id="" @click="saveAndAddonClick()">Lưu và Thêm</button>
                        </div>
                    </div>
                </div>
            </div>
            <NotiDuplicateCode
            :notiMess="this.failRes"
            :isShowNoti ="this.isShowNoti"
            @hideNoti ="hideNoti"
            />
    </div>
</template>
<style>
@import '../../style/Dialog.css';
.missing{
    display: none;
}
.noti{
    padding-right: 10px;
    padding-left: 10px;
    height: 20px;
    top: 33px;
    left: 35px;
    width: fit-content;
    text-align: center;
    font-weight: lighter;
    position: absolute;
    background-color: #393a3d;
    color: #ffffff;
}
.MissingValue{
    border-color: red !important;
}
</style>
<script>
import axios from 'axios';
import NotiDuplicateCode from '../notifications/notiDuplicateCode.vue';

export default {
    components:{
        NotiDuplicateCode,
    },
    created(){
    },
    props:{
        isAddMore:{type : Boolean,default: false},
        employee:{type: Object, default: null},
        isShow:{type:Boolean, default : false},
        formMode:{type:String, default: "add"},
    },  
    methods: {
        MouseOverName(){
            this.isMissingNameEmp = true;
        },
        MouseOverGroup(){
            this.isMissingEmployeeDepartment = true;
        },
        MouseOutName(){
            this.isMissingNameEmp=false;
        },
        MouseOutGroup(){
            this.isMissingEmployeeDepartment = false
        },
        hideNoti(){
            this.isShowNoti = false;
        },
        CancelDialog(){
            this.isMissingNameEmp = false;
            this.isMissingEmployeeDepartment=false;
            this.$emit('hideDialog');
        },
        CloDiaOnClick(){
            this.$emit('hideDialog');
            this.isMissingNameEmp = false;
            this.isMissingEmployeeDepartment=false;
            this.count=0;
        },
        saveAndAddonClick(){
            if(this.employee.employeeCode==""){
                this.isMissingEmployeeCode=true;
            }
            else{
                this.isMissingEmployeeCode=false;
            }
            if(this.employee.fullname==""||this.employee.fullname==null){
                this.isMissingNameEmp=true;
            }
            if(this.employee.departmentId==""||this.employee.departmentId==null){
                this.isMissingEmployeeDepartment=true;
            }
            else{
                this.isMissingNameEmp=false;
            }
            if(this.isMissingEmail==false){
                this.validEmail=""+this.employee.Email;
                
                if(this.validEmail.search("@") < 0 ||this.validEmail.search(".com")<0){
                    this.validEmail=" đúng định dạng:ABC@XYZ.com";
                    this.isMissingEmail=true;
                }
            }
            if(this.isMissingNameEmp==false) 
            {
                if(this.formMode=="add"){
                    axios
                    .post("https://localhost:44333/api/v1/Employees",this.employee)
                    .then((res)=>{
                        this.$emit('AddMore');
                        console.log(res)
                        ///this.Check = true;
                    })
                    .catch((error)=>{
                            this.failRes = error.response.data;
                            this.isShowNoti = true;
                            console.log(this.failRes);
                            console.log(this.failRes);
                    })
                }
                else{
                   axios
                    .put("https://localhost:44333/api/v1/Employees/"+this.employee.employeeId,this.employee)
                    .then((res)=>{
                        this.$emit('AddMore');
                        console.log(res)
                        //this.Check = true;
                    })
                    .catch((res)=>{
                        console.log(res); 
                    })
                }
            }
            
        },
        AddOnClick(){
            if(this.employee.employeeCode==""){
                this.isMissingEmployeeCode=true;
            }
            else{
                this.isMissingEmployeeCode=false;
            }
            if(this.employee.fullname==""||this.employee.fullname==null){
                this.isMissingNameEmp=true;
            }
            if(this.employee.departmentId==""||this.employee.departmentId==null){
                this.isMissingEmployeeDepartment=true;
            }
            else{
                this.isMissingNameEmp=false;
            }
            if(this.isMissingEmail==false){
                this.validEmail=""+this.employee.Email;
                
                if(this.validEmail.search("@") < 0 ||this.validEmail.search(".com")<0){
                    this.validEmail=" đúng định dạng:ABC@XYZ.com";
                    this.isMissingEmail=true;
                }
            }
            if(this.isMissingNameEmp==false) 
            {
                if(this.formMode=="add"){
                    axios
                    .post("https://localhost:44333/api/v1/Employees",this.employee)
                    .then((res)=>{
                        console.log(res)
                        this.$emit('hideDialog');
                    })
                    .catch((error)=>{
                            this.failRes = error.response.data;
                            this.isShowNoti = true;
                            console.log(this.failRes);
                            console.log(this.failRes);
                    })
                }
                else{
                    axios
                    .put("https://localhost:44333/api/v1/Employees/"+this.employee.employeeId,this.employee)
                    .then((res)=>{
                        console.log(res)
                        this.$emit('hideDialog');
                    })
                    .catch((res)=>{
                        console.log(res); 
                    })
                }
            }
        },
    },
    data() {
        return {
            count:0,
            missing : false,
            isMissingEmployeeDepartment :false,
            isMissingNameEmp :false,
            isMissingCMND :false,
            isMissingPhoneNumber :false,
            isMissingEmail :false,
            validEmail:"",
            Check :false,
            failRes : "",
            isShowNoti: false
        }
    },
    watch :{
        isShow(){
            if(this.isShow==true){
               this.$nextTick(()=> this.$refs.employeeCodeFocus.focus());
            }
        },
        isAddMore(){
            if(this.isAddMore==true){
                this.$nextTick(()=> this.$refs.employeeCodeFocus.focus());
            }
        }
    }
}
</script>