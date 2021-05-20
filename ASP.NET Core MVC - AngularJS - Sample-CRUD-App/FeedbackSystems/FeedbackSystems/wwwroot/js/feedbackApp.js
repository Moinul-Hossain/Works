angular.module('feedbackApp', [])
    .controller('FeedbackController', function ($http, $httpParamSerializer) {
        var feedback = this;

        feedback.issues = [
            { id: 1, text: 'ASP.NET Core: Chapter 10 # Web API - Authentication', done: true },
            { id: 2, text: 'Angular 6: Chapter 14 # Forms and Events - Form Validation', done: false }];
        
        feedback.selectedIssues = [];

        feedback.listIssues = function () {
            $http.get('/issues').then(function (response) {
                feedback.issues = response.data.issues;                
            }, function (error) { alert(JSON.stringify(error.data)); });
        };

        feedback.listIssues ();        

        feedback.addIssue = function () {
            //alert('');
            $http({
                method: 'POST',
                url: '/issues/create',
                data: $httpParamSerializer(angular.copy({text: feedback.issueText, done: false})),
                headers: {
                    'Content-Type': 'application/x-www-form-urlencoded'
                }
            }).then(function (response) {
                //alert(JSON.stringify(response.data.issue));
                feedback.issues.push(response.data.issue); feedback.message = 'New issue #' + feedback.issues.length + ' has been raised.';
            }, function (error) { alert("Error occured!\n" + JSON.stringify(error.data)); });
            
            feedback.issueText = '';
        };

        feedback.saveIssue = function () {
            feedback.message = '';
            if (feedback.issueText.length > 0) {                
                if (feedback.selectedIndex >= 0 && feedback.mode === 'edit') {                    
                    //alert(feedback.selectedIndex + '\n' + feedback.mode);
                    feedback.issues[feedback.selectedIndex].text = feedback.issueText;
                    var dataStr = $httpParamSerializer(angular.copy(feedback.issues[feedback.selectedIndex]));
                    //alert(dataStr);                    
                    $http({
                        method: 'POST',
                        url: '/issues/update?',
                        data: dataStr,
                        headers: {
                            'Content-Type': 'application/x-www-form-urlencoded'
                        }
                    }).then(function (response) {
                        //FEEDBACK.SELECTEDINDEX IS NULL? DON'T SHOW MESSAGE
                        //feedback.message = 'Issue #' + (feedback.selectedIndex + 1) + ' has been updated.';
                        feedback.issues[feedback.selectedIndex].text = feedback.issueText;                   
                        }, function (error) { alert("Error occured!\n" + JSON.stringify(error)); });

                }
                else feedback.addIssue();                
            }
            // common tasks
            feedback.issueText = '';
            feedback.mode = null;
            feedback.selectedIndex = null;
        };

        feedback.remaining = function () {
            var count = 0;
            angular.forEach(feedback.issues, function (issue) {
                count += issue.done ? 0 : 1;
            });
            return count;
        };

        feedback.delete = function () {
            var oldissues = feedback.issues;
            feedback.issues = [];
            angular.forEach(oldissues, function (issue) {
                if (!issue.done) 
                    feedback.issues.push(issue);
            });
            angular.forEach(feedback.issues, function (issue) { oldissues.splice(oldissues.indexOf(issue), 1);});
            //var dataStr = $httpParamSerializer(angular.copy(oldissues));
            //alert(dataStr);
            $http({
                method: 'POST',
                url: '/issues/delete?',
                data: JSON.stringify(oldissues), //dataStr,
                headers: {
                    //'Content-Type': 'application/x-www-form-urlencoded'
                    'Content-Type': 'application/json'
                }
            }).then(function (response) {
                //FEEDBACK.SELECTEDINDEX IS NULL? DON'T SHOW MESSAGE
                //feedback.message = 'Issue #' + (feedback.selectedIndex + 1) + ' has been updated.';
                alert(JSON.stringify(respons.data.issues));
                feedback.message = oldissues.length + ' issues deleted.';
            }, function (error) { alert("Error occured!\n" + JSON.stringify(error)); });
        };

        feedback.archive = function () {
            feedback.delete();
        };

        feedback.editIssue = function (i) {
            feedback.mode = 'edit';
            feedback.selectedIndex = i;            
            feedback.issueText = feedback.issues[i].text;               
        };

        feedback.cancelEdit = function (i) {
            feedback.mode = null;            
            feedback.issueText = '';
        };

        feedback.setResolved = function (i) {
            $http.get('/issues/resolve/' + feedback.issues[i].id).then(function (response) {
                feedback.message = 'Issue #' + (i+1) +' has been resolved.';
            }, function (error) { alert(JSON.stringify(error.data)); });
        };

        feedback.setUnresolved = function (i) {
            $http.get('/issues/raise/' + feedback.issues[i].id).then(function (response) {
                feedback.message = 'Issue #' + (i+1) + ' has been raised.';
            }, function (error) { alert(JSON.stringify(error.data)); });
        };

        feedback.changeStatus = function (i, done) {
            
            if (done) {
                feedback.setResolved(i);
                feedback.selectedIssues.push(feedback.issues[i]);
                document.getElementById('span' + i).innerText = '(Resolved)';
            }
            else {
                feedback.setUnresolved(i);
                var index = feedback.selectedIssues.indexOf(feedback.issues[i]);
                if (index > -1) {
                    feedback.selectedIssues.splice(index, 1);
                }                
                document.getElementById('span' + i).innerText = 'Not Resolved';
            }

            feedback.issueText = '';
        };
    });
