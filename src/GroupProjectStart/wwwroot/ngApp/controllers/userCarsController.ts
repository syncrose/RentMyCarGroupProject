namespace GroupProjectStart.Controllers {

    export class UserCarsController {
        public users;
        public ratingPercent;
        public totalCars;
        public currentPage = 1;
        public maxSize = 3;
        public itemsPerPage = 2;



        constructor(
            private userCarsService: GroupProjectStart.Services.UserCarsService, private $uibModal: ng.ui.bootstrap.IModalService) {
            this.totalCars = 0;
            this.getCars();
        }

        //Method to get a total list of cars
        getCars() {
            this.userCarsService.getTotalCars().then((data) => {
                this.totalCars = data.length;
            });

            this.userCarsService.getCarPage(this.currentPage).then((data) => {
                this.users = data;
            });
        }

        //Modal to rate and submit a car rating
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

        //Modal to rate and submit a applicationuser rating
        public driverRateModal(id) {

            this.$uibModal.open({
                templateUrl: '/ngApp/views/modalViews/rateDriver.html',
                controller: GroupProjectStart.Controllers.CreateDriverRatingController,
                controllerAs: 'controller',
                resolve: {
                    id: () => id,

                },
                size: 'lg'
            });

        }


    }

    export class UserCarController {
        public user;
        public car;
        public carReviews;
        public userReviews;
        public errorMessages;

        constructor(
            private userCarsService: GroupProjectStart.Services.UserCarsService,
            private carReviewService: GroupProjectStart.Services.CarReviewService,
            private carService: GroupProjectStart.Services.CarService,
            private driverReviewService: GroupProjectStart.Services.DriverReviewService,
            private $stateParams: ng.ui.IStateParamsService,
            private $state: ng.ui.IStateService,
            private $uibModal: ng.ui.bootstrap.IModalService
        ) {
            this.getUser();
        }

        //Method to get a single user
        public getUser() {
          
            let userId = this.$stateParams['user'];
            let carId = this.$stateParams['car'];
            this.user = this.userCarsService.getUser(userId);
            this.car = this.carService.getCar(carId);

            
        }

        //Method to get a particular user's reviews
        public getOwnerReviews(id) {
            
            this.userReviews = this.driverReviewService.getDriverReview(id);
        }

        //Modal to add a review to a car
        public carReviewModal(id) {

            this.$uibModal.open({
                templateUrl: '/ngApp/views/modalViews/carReviewAdd.html',
                controller: GroupProjectStart.Controllers.CreateCarReviewController,
                controllerAs: 'controller',
                resolve: {
                    id: () => id,

                },
                size: 'md'
            });

        }

        //Modal to add a review to a user
        public driverReviewModal(id) {

            this.$uibModal.open({
                templateUrl: '/ngApp/views/modalViews/driverReviewAdd.html',
                controller: GroupProjectStart.Controllers.CreateDriverReviewController,
                controllerAs: 'controller',
                resolve: {
                    id: () => id,

                },
                size: 'md'
            });

        }

        //Modal to view all user reviews
        public viewDriverReviews(id) {

            this.$uibModal.open({
                templateUrl: '/ngApp/views/modalViews/driverReviews.html',
                controller: GroupProjectStart.Controllers.CreateDriverReviewController,
                controllerAs: 'controller',
                resolve: {
                    id: () => id,

                },
                size: 'lg'
            });

        }
        
        // Modal to rate a car
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

        //Modal to rate a user
        public driverRateModal(id) {

            this.$uibModal.open({
                templateUrl: '/ngApp/views/modalViews/rateDriver.html',
                controller: GroupProjectStart.Controllers.CreateDriverRatingController,
                controllerAs: 'controller',
                resolve: {
                    id: () => id,

                },
                size: 'lg'
            });

        }

        //Modal to view all user reviews
        public ownerReviewDetails(id) {

            this.$uibModal.open({
                templateUrl: '/ngApp/views/modalViews/driverReviewDetails.html',
                controller: GroupProjectStart.Controllers.UserCarController,
                controllerAs: 'controller',
                resolve: {
                    id: () => id,

                },
                size: 'lg'
            });

        }

        //Modal to view all car reviews
        public carReviewDetails(id) {

            this.$uibModal.open({
                templateUrl: '/ngApp/views/modalViews/carReviewDetails.html',
                controller: GroupProjectStart.Controllers.UserCarController,
                controllerAs: 'controller',
                resolve: {
                    id: () => id,

                },
                size: 'lg'
            });

        }

    }
}