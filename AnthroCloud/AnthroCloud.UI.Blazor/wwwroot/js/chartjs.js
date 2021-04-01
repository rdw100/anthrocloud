window.drawChart = (data, options) => {
    google.charts.load('current', { 'packages': ['corechart'] });
    google.setOnLoadCallback(drawGoogleChart);
    function drawGoogleChart() {
        var jData = new google.visualization.DataTable(data);

        var chart = new google.visualization.LineChart(document.getElementById('line_top_x'));

        chart.draw(jData, options);
    }
};
