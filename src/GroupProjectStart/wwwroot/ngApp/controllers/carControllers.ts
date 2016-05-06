﻿namespace GroupProjectStart.Controllers {

    export class CarsController {
        public cars;
        public totalItems;
        public currentPage = 1;
        public maxSize = 3;
        public itemsPerPage = 4;

        constructor(private carService: GroupProjectStart.Services.CarService,
            private $uibModal: ng.ui.bootstrap.IModalService,
            public $stateParams: ng.ui.IStateParamsService) {

            this.totalItems = 0;
            this.getCars();
        }

        //Method to get all cars
        getCars() {
            this.carService.getCarsAmount().then((data) => {
                this.totalItems = data.length;
              
            });
            this.carService.getCarsShortList(this.currentPage).then((data) => {
                this.cars = data;
               
            });
        }

        //Method to determine/set page
        setPage(pageNo) {

            this.currentPage = pageNo;
        }

        public nextpage() {
            this.getCars();
        }

        public carRateModal(id) {

            this.$uibModal.open({
                templateUrl: '/ngApp/views/modalViews/rateCar.html',
                controller: GroupProjectStart.Controllers.CreateCarRatingController,
                controllerAs: 'controller',
                resolve: {
                    id: () => id,

                },
                size: 'lg'
            });

        }

    }

    export class CarFormController {
        public carToAdd;
        public file;
        public image;
        public userId;
        public errorMessages;

        constructor(
            private carService: GroupProjectStart.Services.CarService,
            private $state: ng.ui.IStateService,
            private filepickerService: any,
            private $scope: ng.IScope) {
            
        }

        //Method save a car
        saveCar(id, carToAdd) {
            this.carToAdd.image = this.image
            this.carService.saveCar(this.userId, this.carToAdd).then(() => {
              
                this.$state.go('cars');
            }).catch((err) => {
               
            });
        }

        cancel() {
            this.$state.go('cars');
        }


        public pickFile() {
            this.filepickerService.pick({
                mimetype: 'image/*',
            }, this.fileUploaded.bind(this));
        }

        private fileUploaded(file) {
            this.file = file;
            this.$scope.$apply();
            this.image = file.url;
        }       
    }
}