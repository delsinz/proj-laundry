// Author: Mingyang Zhang

$('table').on('click', 'button[role="button-remove"]', function(e){
   $(this).closest('tr').remove()
})
