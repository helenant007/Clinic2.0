(function () {

    angular.module('AppClinic').controller('dailyvisitor', ['$http', ctrl]);
    //trus dikasih [] tadi lu bilang biar apa?
    //dikasih [ ] itu cara pakenya , sebutannya dependency 
    //gunanya untuk?  something about uglify and ya imniygf taydi itu 

    function ctrl(ABCD) { 
        var vm = this;
        ref = vm;

        vm.selectMonth = (new Date().getMonth() + 1).toString();
        vm.monthsInYear = [];
        vm.med = null;
        vm.medNames = [];
        vm.sectionList = [];
        vm.diagnoses = [];
        vm.visitors = [];

        vm.addVisitorForm = {
            Data: {
                Anamnesis: null,
                Implementation: null,
                Diagnose: 'null',
                Notes: null,
                Gender: 'null',
                BloodType: 'null',
                BinusianID: null,
                Name: null,
                Phone: null,
                Section: 'null',
                VisitDate: today,
            },
            Valid: {
                Anamnesis: true,
                Implementation: true,
                Diagnose: true,
                Gender: true,
                BloodType: true,
                Notes: true,
                BinusianID: false,
                Name: true,
                Phone: true,
                Section: true,
                VisitDate: true,
                UseMedicine: 'null'
            },

        };

        vm.usedItemForms = {
            usedItems: [{ MedName: "null", Qty: undefined }], // Type, Qty

            addForm: function () {
                vm.usedItemForms.usedItems.push({
                    MedName: undefined,
                    Qty: undefined
                });
            },
            deleteForm: function () {

            }
        };

        vm.submitVisitorForm = function () {


            vm.addVisitorForm.Data.Arr = vm.usedItemForms.usedItems;
            $http.post('@Url.Action("CreateVisitor")', vm.addVisitorForm.Data).then(
                function success(res) {
                    vm.visitors.push(res.data);

                    //bikin data nya jd default lagi stlh di push
                    vm.addVisitorForm.Data = {
                        Anamnesis: null,
                        Implementation: null,
                        Diagnose: 'null',
                        Notes: null,
                        Gender: 'null',
                        BloodType: 'null',
                        BinusianID: null,
                        Name: null,
                        Phone: null,
                        Section: 'null',
                        VisitDate: today
                    };

                    vm.addVisitorForm.Data.UseMedicine = 'null';
                    vm.successAdd();
                },
                function error(res) {
                    alert('Server error');
                });

        }

        vm.successAdd = function () {
            $('#modalAddSuccess').modal('show');
            setTimeout(function () {
                $('#modalAddSuccess').modal('hide');
            }, 1000);
        }



        vm.modal = {
            data: null,
            selectData: function (visitor) {
                debugger;
                vm.modal.data = visitor;
                refS = vm.modal.data;
            }
        }


        vm.deleteData = vm.modal.data;


        // misal ada arr [3,5, 'A', 10, 'Ba']   kita slice array tesebut , slice(2,1), artinya si 'A' kita buang, karena 'A' merupakan indeks ke 2 dari Array tsb
        // misal ada arr [3,5, 'A', 10, 'Ba']   kita slice array tesebut , slice(2,3), artinya si 'A', 10, 'Ba' kita buang, karena kita buang indeks dgn jarak 2 sampai 2 + 3 , artinya 2 sampai 5
        // kalo yg indexof vm.modal data, berarti kita buang length dari si modal.data + 1? oh indexof itu -1 dari length iya icic. jadi di splice dulu baru bisa ke delete ya
        //ga bisa langsung delete aja? :") ga bisa, ini bukan C# hadeh2 javascript wkwkw ok bos wkwkwk oke.

        vm.removeVisitor = function () {

            $http.post('@Url.Action("DeleteVisitor")', { id: vm.modal.data.Id }).then(successCallback, failCallback);

            function successCallback(res) {
                if (res.data == true) {
                    vm.visitors.splice(vm.visitors.indexOf(vm.modal.data), 1);
                }
            }
            function failCallback(res) {
                alert('Server error');
            }
        }


        $http.post('@Url.Action("GetDailyVisitors")').then(function success(res) {
            vm.visitors = res.data;
        });

        $http.post('@Url.Action("GetMonthsData","Shared")').then(function success(res) {
            vm.monthsInYear = res.data;
        });

        $http.post('@Url.Action("GetSectionList","Shared")').then(function success(res) {
            vm.sectionList = res.data;
        });

        $http.post('@Url.Action("GetDiagnoses","Shared")').then(function success(res) {
            vm.diagnoses = res.data;
        });

        $http.post('@Url.Action("GetMedicineNames","Shared")').then(function success(res) {
            vm.medNames = res.data;
        });


    }
})()