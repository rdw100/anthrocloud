// To create a chart, we need to instantiate the Chart class.
window.setup = (id, config) => {
    var ctx = document.getElementById(id).getContext('2d');
    new Chart(ctx, config);
}