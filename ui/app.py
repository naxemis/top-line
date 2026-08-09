from enum import Enum
from ui.views.start import StartView

import flet

class Views(Enum):
    START = StartView

class App:
    def __init__(self, page: flet.Page):
        self.page = page

        self._setup_page()

        self.current_view: Views = Views.START
        self._run_current_view()

    def _setup_page(self):
        self.page.title = "TopLine"
        self.page.theme_mode = flet.ThemeMode.SYSTEM

        self.page.window.height = 480
        self.page.window.width = 640
        self.page.window.resizable = False

        self.page.vertical_alignment = flet.MainAxisAlignment.CENTER
        self.page.horizontal_alignment = flet.CrossAxisAlignment.CENTER

    def change_view(self, new_view: Views):
        self.current_view = new_view
        self._run_current_view()

    def _run_current_view(self):
        view_class = self.current_view.value # retrieve the view class stored as the enum value (line 6)
        view_instance = view_class(self.page) # then instantiate it by passing the main flet view instance

        self.page.clean()
        view_instance.run()