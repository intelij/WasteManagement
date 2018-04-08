route('/', 'complain', function () {
    $.get(baseUrl + 'complain', function (data) {
        this.complains = data.complaints;
        //ko.cleanNode(document.getElementById("contact"));
        ko.applyBindings(new ComplainListModel(data), document.getElementById("contact"));
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
        this.resetForm = function () {
            this.Name("");
            this.Email("");
            this.ContactNumber("");
            this.Location("");
            this.Compactor("");
            this.Decription("");
        }
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

            $.ajax({
                url: baseUrl + 'complain',
                type: 'POST',
                data: JSON.stringify(newComplain),
                contentType: 'application/json',
                success: function () {
                    alert('record added successfully');
                }

            })
            this.resetForm();
        }

            .bind(this);
    };
});
