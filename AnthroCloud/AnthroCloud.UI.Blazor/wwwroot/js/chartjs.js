window.drawChart = (data, options) => {
    google.charts.load('current', { 'packages': ['line'] });
    google.setOnLoadCallback(drawGoogleChart);
    function drawGoogleChart() {
        //var jData = new google.visualization.arrayToDataTable(data);
        //var jData = new google.visualization.arrayToDataTable(data, false);
        var jData = new google.visualization.DataTable(data);

        var chart = new google.charts.Line(document.getElementById('line_top_x'));

        chart.draw(jData, google.charts.Line.convertOptions(options));
    }
};
