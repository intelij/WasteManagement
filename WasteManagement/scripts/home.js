
route('/', 'index', function () {
    $.get(baseUrl + 'home', function (data) {
        this.dashboardDatas = data;

        ko.cleanNode(document.getElementById("view"));
        ko.applyBindings(this.dashboardDatas, document.getElementById("view"));
    });

});

route('/Deployments', 'deployment', function () {
    displayData = function () {
        if ($('#txtDeploymentDate').val()) {
            $('#dvContainer').show();
        } else {
            alert('Please select date');
        }

    }
    $.get(baseUrl + 'DeploymentSheet?deploymentDate=' + $("#txtDeploymentDate").val(), function (data) {
        ko.cleanNode(document.getElementById("view"));

        ko.applyBindings(new DeploymentSheetModel(data), document.getElementById("view"));
    });


    var DeploymentSheetModel = function (item) {
        this.availableDriver = ko.observableArray(item.AvailableDriver);
        this.availableCrew = ko.observableArray(item.AvailableCrew);
        this.availableWorker = ko.observableArray(item.AvailableWorker);
        this.deploymentSheet = ko.observableArray(item.DeploymentSheet);
    }.bind(this);

});

route('/person', 'person', function () {
    $.get(baseUrl + 'person', function (data) {
        this.persons = data;

        ko.cleanNode(document.getElementById("view"));
        ko.applyBindings(new PersonList(data), document.getElementById("view"));
    });
    var PersonList = function (items) {
        this.persons = ko.observableArray(items);
        this.Id = ko.observable("");
        this.Name = ko.observable("");
        this.Email = ko.observable("");
        this.Phone = ko.observable("");
        this.StaffType = ko.observable("");

        this.resetForm = function () {
            this.Name("");
            this.Email("");
            this.Phone("");
            this.StaffType("0");
        }
        this.addPerson = function () {
            var newPerson = {
                Id: this.Id(),
                Name: this.Name(),
                Email: this.Email(),
                StaffType: this.StaffType(),
                StaffTypeName: $("#staffType option:selected").text(),
                Phone: this.Phone(),

            }


            if (newPerson.Name == "" || newPerson.Email == "" || newPerson.Phone == "" || newPerson.StaffType == "0") {
                alert('Please fill all values');
                return;
            }


            this.persons.push(newPerson);
            $.ajax({
                url: baseUrl + 'person',
                data: JSON.stringify(newPerson),
                contentType: 'application/json',
                method: 'POST',
                success: function () {
                    alert('Record added successfully');
                }
            });
            this.resetForm();

        }
        this.updatePerson = function (person) {
            alert(JSON.stringify(person));
            this.Id = ko.observable(person.Id);
            this.Name = ko.observable(person.Name);
            this.Email = ko.observable(person.Email);
            this.Phone = ko.observable(person.Phone);

        }
        this.removePerson = function (person) {
            this.persons.remove(person);
        }
            .bind(this);
    };



});

route('/vehicle', 'vehicle', function () {
    $.get(baseUrl + 'vehicle', function (data) {
        ko.cleanNode(document.getElementById("view"));
        ko.applyBindings(new SimpleListModel(data), document.getElementById("view"));
    });

    var SimpleListModel = function (items) {
        this.vehicles = ko.observableArray(items);

        this.VehicleNumber = ko.observable("");
        this.RegistrationYear = ko.observable("");
        this.ServiceProvider = ko.observable("");
        this.VehicleDetails = ko.observable("");
        this.resetForm = function () {
            this.VehicleNumber("");
            this.RegistrationYear("");
            this.ServiceProvider("");
            this.VehicleDetails("");
        }
        this.addVehicle = function () {

            var newVehicle = {
                VehicleNumber: this.VehicleNumber(),
                VehicleDetails: this.VehicleDetails(),
                ServiceProvider: this.ServiceProvider(),
                RegistrationYear: this.RegistrationYear()
            }

            if (newVehicle.VehicleNumber == "" || newVehicle.VehicleDetails == "" || newVehicle.RegistrationYear == "") {
                alert('Please fill all values');
                return;
            }

            this.vehicles.push(newVehicle);

            this.resetForm();

            $.ajax({
                url: baseUrl + 'vehicle',
                type: 'POST',
                data: JSON.stringify(newVehicle),
                contentType: 'application/json',
                success: function () {
                    alert('Record added successfully');
                }
            })
        }
        this.removeVehicle = function (vehicle) {
            this.vehicles.remove(vehicle);
        }
            .bind(this);
    };
});
route('/route', 'route', function () {
    $.get(baseUrl + 'route', function (data) {
        ko.cleanNode(document.getElementById("view"));
        ko.applyBindings(new RouteModel(data), document.getElementById("view"));
    });
    var RouteModel = function (items) {
        this.routes = ko.observableArray(items.Routes);
        this.vehicles = ko.observableArray(items.Vehicles);
        this.staffs = ko.observableArray(items.staffs);

        var crews = items.Staffs.filter(function (item) {
            return item.StaffType == 2;
        });
        var drivers = items.Staffs.filter(function (item) {
            return item.StaffType == 1;
        });
        var worker = items.Staffs.filter(function (item) {
            return item.StaffType == 3;
        });

        this.crews = ko.observableArray(crews);
        this.drivers = ko.observableArray(drivers);
        this.workers = ko.observableArray(worker);

        this.locationLists = ko.observableArray(items.Locations);

        this.RouteNumber = ko.observable("");
        this.VehicleNo = ko.observable("");
        this.DriverID = ko.observable("");
        this.CrewID = ko.observable("");
        this.WorkerID = ko.observable("");
        this.locations = ko.observableArray("");
        this.resetForm = function () {
            this.RouteNumber("");
            this.VehicleNo("");
            this.DriverID("");
            this.CrewID("");
            this.WorkerID("");
            this.locations([]);
        }

        this.addRoute = function () {
            var newRoute = {
                RouteNumber: this.RouteNumber(),
                VehicleNo: this.VehicleNo(),
                DriverID: this.DriverID(),
                CrewID: this.CrewID(),
                WorkerID: this.WorkerID(),
                locations: this.locations(),
                Driver: "",
                Crew: "",
                Worker: ""
            }
            this.routes.push(newRoute);

            if (newRoute.RouteNumber == "" || newRoute.VehicleNo == undefined || newRoute.DriverID == undefined || newRoute.CrewID == undefined || newRoute.WorkerID == undefined ||
                newRoute.locations == undefined) {
                alert('Please fill all values');
                return;
            }

            $.ajax({
                url: baseUrl + 'route',
                type: 'POST',
                data: JSON.stringify(newRoute),
                contentType: 'application/json',
                success: function () {
                    alert('New Route added successfully');
                }
            })
            this.resetForm();

        }
        this.removeRoute = function (route) {
            this.routes.remove(route);
        }
            .bind(this);
    };
});

route('/complain', 'complain', function () {
    $.get(baseUrl + 'complain', function (data) {
        this.complains = data.complaints;
        ko.cleanNode(document.getElementById("view"));
        ko.applyBindings(new ComplainListModel(data), document.getElementById("view"));
    });
    var ComplainListModel = function (items) {
        this.complains = ko.observableArray(items.complaints);
        this.locations = ko.observableArray(items.locations);
        this.compactors = ko.observableArray(items.compactors);

        this.Name = ko.observable("");
        this.Email = ko.observable("");
        this.ContactNumber = ko.observable("");
        this.Location = ko.observable("");
        this.Compactor = ko.observable("");
        this.Decription = ko.observable("");

        this.addComplain = function () {

            var newComplain = {

                //      this.complains.push({

                Name: this.Name(),

                Email: this.Email(),

                ContactNumber: this.ContactNumber(),

                Location: this.Location(),

                Compactor: this.Compactor(),

                Decription: this.Decription()

                //});
            };
            this.complains.push(newComplain);

            this.Name = ko.observable("");
            this.Email = ko.observable("");
            this.ContactNumber = ko.observable("");
            this.Location = ko.observable("");
            this.Compactor = ko.observable("");
            this.Decription = ko.observable("");

            $.ajax({
                url: baseUrl + 'complain',
                type: 'POST',
                data: JSON.stringify(newComplain),
                contentType: 'application/json',
                success: function () {
                    alert('record added successfully');
                }

            })

        }

            .bind(this);
    };
});
route('/compactor', 'compactor', function () {
    $.get(baseUrl + 'compactor', function (data) {
        this.compactors = data.Compactors;

        ko.cleanNode(document.getElementById("view"));
        ko.applyBindings(new CompactorModel(data), document.getElementById("view"));
    });
    var CompactorModel = function (items) {
        this.compactors = ko.observableArray(items.Compactors);
        this.locations = ko.observableArray(items.Locations);
        console.log(this.compactors);

        this.CompactorNumber = ko.observable("");
        this.Size = ko.observable("");
        this.Make = ko.observable("");
        this.Location = ko.observable("");
        this.LocationId = ko.observable("");
        this.resetForm = function () {
            this.CompactorNumber("");
            this.Size("");
            this.Make("");
            this.LocationId("");
        }

        this.addCompactor = function () {
            var newCompactor = {
                CompactorNumber: this.CompactorNumber(),
                Size: this.Size(),
                Make: this.Make(),
                LocationId: this.LocationId(),
                Location: $("#location option:selected").text(),
            }

            if (newCompactor.CompactorNumber == "" || newCompactor.Size == "" || newCompactor.Make == "" || newCompactor.LocationId == "") {
                alert('Please fill all values');
                return;
            }



            this.compactors.push(newCompactor);

            $.ajax({
                url: baseUrl + 'compactor',
                type: 'POST',
                data: JSON.stringify(newCompactor),
                contentType: 'application/json',
                success: function () {
                    alert('record added successfully');
                }
            })
            this.resetForm();
        }
        this.removeCompactor = function (compactor) {
            this.compactors.remove(compactor);
        }
            .bind(this);
    };
});

route('/location', 'location', function () {
    $.get(baseUrl + 'location', function (data) {
        ko.cleanNode(document.getElementById("view"));
        ko.applyBindings(new LocationListModel(data), document.getElementById("view"));
    });
    var LocationListModel = function (items) {
        this.locations = ko.observableArray(items);
    };
});