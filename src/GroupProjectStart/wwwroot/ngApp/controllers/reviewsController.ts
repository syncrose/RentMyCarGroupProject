namespace GroupProjectStart.Controllers {


    export class DriverReviewController {
        public reviews;
        public userId;
        public errorMessages;

        constructor(
            private driverReviewService: GroupProjectStart.Services.DriverReviewService,
            private accountService: GroupProjectStart.Services.AccountService,
            private $state: ng.ui.IStateService,
            private $stateParams: ng.ui.IStateParamsService,
            private $uibModalInstance: ng.ui.bootstrap.IModalServiceInstance,
            private id
        ) {
          

        }

        public ok() {
            this.$uibModalInstance.close();
        }


        //Method to retrieve all user reivews
        getReviews() {

            this.reviews = this.driverReviewService.getDriverReviews();
        }
    }

    export class CreateCarReviewController {
        public reviewToCreate;
        public carId;
        public errorMessages;

        constructor(
            private carReviewService: GroupProjectStart.Services.CarReviewService,
            private accountService: GroupProjectStart.Services.AccountService,
            private $state: ng.ui.IStateService,
            private $stateParams: ng.ui.IStateParamsService,
            private $uibModalInstance: ng.ui.bootstrap.IModalServiceInstance,
            private id
        ) {
            this.carId = this.$stateParams['id'];
       
        }

        public ok() {
            this.$uibModalInstance.close();
        }

      
        //Method to save a car review
        saveCarReview() {
            
            this.carReviewService.saveCarReview(this.id, this.reviewToCreate).then(() => {

                this.ok();
                this.$state.reload();
            }).catch((err) => {
                this.errorMessages = err.data;
            });               
        }
    }

    export class CreateDriverReviewController {
        public reviewToCreate;
        public userId;
        public errorMessages;

        constructor(
            private driverReviewService: GroupProjectStart.Services.DriverReviewService,
            private accountService: GroupProjectStart.Services.AccountService,
            private $state: ng.ui.IStateService,
            private $stateParams: ng.ui.IStateParamsService,
            private $uibModalInstance: ng.ui.bootstrap.IModalServiceInstance,
            private id
        ) {
            this.userId = this.$stateParams['id'];
        }

        public ok() {
            this.$uibModalInstance.close();
        }

        //Method to save a user review
        saveDriverReview() {
            this.driverReviewService.saveDriverReview(this.id, this.reviewToCreate).then(() => {
                this.ok();
                this.$state.reload();
            }).catch((err) => {
                this.errorMessages = err.data;
            });
        }
    }

    export class DeleteCarReviewController {
        public ratingToDelete;
        public carId;

        constructor(
            private carReviewService: GroupProjectStart.Services.CarReviewService,
            private $stateParams: ng.ui.IStateParamsService,
            private $state: ng.ui.IStateService
        ) {
            this.carId = this.$stateParams['id'];
        }

        //Method to delete a car review
        deleteCarReview() {
            this.carReviewService.deleteCarReview(this.$stateParams['id']);
        }
    }

    export class DeleteDriverReviewController {
        public ratingToDelete;
        public userId;

        constructor(
            private driverReviewService: GroupProjectStart.Services.DriverReviewService,
            private $stateParams: ng.ui.IStateParamsService,
            private $state: ng.ui.IStateService
        ) {
            this.userId = this.$stateParams['id'];
        }

        //Method to delete a user review
        deleteDriverReview() {
            this.driverReviewService.deleteDriverReview(this.$stateParams['id']);
        }
    }

}