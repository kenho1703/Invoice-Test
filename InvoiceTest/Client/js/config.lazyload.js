// lazyload config

angular.module('app')
    /**
   * jQuery plugin config use ui-jq directive , config the js and css files that required
   * key: function name of the jQuery plugin
   * value: array of the css js file located
   */
  .constant('JQ_CONFIG', {
      easyPieChart:   ['Client/vendor/jquery/charts/easypiechart/jquery.easy-pie-chart.js'],
      sparkline:      ['Client/vendor/jquery/charts/sparkline/jquery.sparkline.min.js'],
      plot:           ['Client/vendor/jquery/charts/flot/jquery.flot.min.js', 
                          'Client/vendor/jquery/charts/flot/jquery.flot.resize.js',
                          'Client/vendor/jquery/charts/flot/jquery.flot.tooltip.min.js',
                          'Client/vendor/jquery/charts/flot/jquery.flot.spline.js',
                          'Client/vendor/jquery/charts/flot/jquery.flot.orderBars.js',
                          'Client/vendor/jquery/charts/flot/jquery.flot.pie.min.js'],
      slimScroll:     ['Client/vendor/jquery/slimscroll/jquery.slimscroll.min.js'],
      sortable:       ['Client/vendor/jquery/sortable/jquery.sortable.js'],
      nestable:       ['Client/vendor/jquery/nestable/jquery.nestable.js',
                          'Client/vendor/jquery/nestable/nestable.css'],
      filestyle:      ['Client/vendor/jquery/file/bootstrap-filestyle.min.js'],
      slider:         ['Client/vendor/jquery/slider/bootstrap-slider.js',
                          'Client/vendor/jquery/slider/slider.css'],
      chosen:         ['Client/vendor/jquery/chosen/chosen.jquery.min.js',
                          'Client/vendor/jquery/chosen/chosen.css'],
      TouchSpin:      ['Client/vendor/jquery/spinner/jquery.bootstrap-touchspin.min.js',
                          'Client/vendor/jquery/spinner/jquery.bootstrap-touchspin.css'],
      wysiwyg:        ['Client/vendor/jquery/wysiwyg/bootstrap-wysiwyg.js',
                          'Client/vendor/jquery/wysiwyg/jquery.hotkeys.js'],
      dataTable:      ['Client/vendor/jquery/datatables/jquery.dataTables.min.js',
                          'Client/vendor/jquery/datatables/dataTables.bootstrap.js',
                          'Client/vendor/jquery/datatables/dataTables.bootstrap.css'],
      vectorMap:      ['Client/vendor/jquery/jvectormap/jquery-jvectormap.min.js', 
                          'Client/vendor/jquery/jvectormap/jquery-jvectormap-world-mill-en.js',
                          'Client/vendor/jquery/jvectormap/jquery-jvectormap-us-aea-en.js',
                          'Client/vendor/jquery/jvectormap/jquery-jvectormap.css'],
      footable:       ['Client/vendor/jquery/footable/footable.all.min.js',
                          'Client/vendor/jquery/footable/footable.core.css']
      }
  )
  // oclazyload config
  .config(['$ocLazyLoadProvider', function($ocLazyLoadProvider) {
      // We configure ocLazyLoad to use the lib script.js as the async loader
      $ocLazyLoadProvider.config({
          debug:  true,
          events: true,
          modules: [
              {
                  name: 'ngGrid',
                  files: [
                      'Client/vendor/modules/ng-grid/ng-grid.min.js',
                      'Client/vendor/modules/ng-grid/ng-grid.min.css',
                      'Client/vendor/modules/ng-grid/theme.css'
                  ]
              },
              {
                  name: 'ui.grid',
                  files: [
                      'Client/vendor/modules/angular-ui-grid/ui-grid.min.js',
                      'Client/vendor/modules/angular-ui-grid/ui-grid.min.css'
                  ]
              },
              {
                  name: 'ui.select',
                  files: [
                      'Client/vendor/modules/angular-ui-select/select.min.js',
                      'Client/vendor/modules/angular-ui-select/select.min.css'
                  ]
              },
              {
                  name:'angularFileUpload',
                  files: [
                    'Client/vendor/modules/angular-file-upload/angular-file-upload.min.js'
                  ]
              },
              {
                  name:'ui.calendar',
                  files: ['Client/vendor/modules/angular-ui-calendar/calendar.js']
              },
              {
                  name: 'ngImgCrop',
                  files: [
                      'Client/vendor/modules/ngImgCrop/ng-img-crop.js',
                      'Client/vendor/modules/ngImgCrop/ng-img-crop.css'
                  ]
              },
              {
                  name: 'angularBootstrapNavTree',
                  files: [
                      'Client/vendor/modules/angular-bootstrap-nav-tree/abn_tree_directive.js',
                      'Client/vendor/modules/angular-bootstrap-nav-tree/abn_tree.css'
                  ]
              },
              {
                  name: 'toaster',
                  files: [
                      'Client/vendor/modules/angularjs-toaster/toaster.js',
                      'Client/vendor/modules/angularjs-toaster/toaster.css'
                  ]
              },
              {
                  name: 'textAngular',
                  files: [
                      'Client/vendor/modules/textAngular/textAngular-sanitize.min.js',
                      'Client/vendor/modules/textAngular/textAngular.min.js'
                  ]
              },
              {
                  name: 'vr.directives.slider',
                  files: [
                      'Client/vendor/modules/angular-slider/angular-slider.min.js',
                      'Client/vendor/modules/angular-slider/angular-slider.css'
                  ]
              },
              {
                  name: 'com.2fdevs.videogular',
                  files: [
                      'Client/vendor/modules/videogular/videogular.min.js'
                  ]
              },
              {
                  name: 'com.2fdevs.videogular.plugins.controls',
                  files: [
                      'Client/vendor/modules/videogular/plugins/controls.min.js'
                  ]
              },
              {
                  name: 'com.2fdevs.videogular.plugins.buffering',
                  files: [
                      'Client/vendor/modules/videogular/plugins/buffering.min.js'
                  ]
              },
              {
                  name: 'com.2fdevs.videogular.plugins.overlayplay',
                  files: [
                      'Client/vendor/modules/videogular/plugins/overlay-play.min.js'
                  ]
              },
              {
                  name: 'com.2fdevs.videogular.plugins.poster',
                  files: [
                      'Client/vendor/modules/videogular/plugins/poster.min.js'
                  ]
              },
              {
                  name: 'com.2fdevs.videogular.plugins.imaads',
                  files: [
                      'Client/vendor/modules/videogular/plugins/ima-ads.min.js'
                  ]
              },
              {
                  name: 'xeditable',
                  files: [
                      'Client/vendor/modules/angular-xeditable/js/xeditable.min.js',
                      'Client/vendor/modules/angular-xeditable/css/xeditable.css'
                  ]
              }
          ]
      });
  }])
;