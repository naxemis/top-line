from enum import *
from ui.pages.start import StartPage

import flet

class Pages(Enum):
    START = StartPage

class App:
    def __init__(self, page: flet.Page):
        self.page = page
        self.current_page: Pages = Pages.START
        self._run_current_page()

    def change_page(self, new_page: Pages):
        self.current_page = new_page
        self._run_current_page()

    def _run_current_page(self):
        page_class = self.current_page.value # retrieve the page class stored as the enum value (line 6)
        page_instance = page_class(self.page) # then instantiate it by passing the main flet page instance

        self.page.clean()
        page_instance.run()