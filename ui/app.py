from enum import *
from ui.pages.start import StartPage

import flet

class Pages(Enum):
    START = StartPage

class App:
    def __init__(self, page: flet.Page):
        self.page = page
        self.current_page: Pages = Pages.START

    def change_page(self, new_page: Pages):
        self.current_page = new_page
        self.run_current_page()

    def run_current_page(self):
        page_class = self.current_page.value
        page_instance = page_class(self.page)

        self.page.clean()
        page_instance.run()