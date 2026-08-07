import flet

from ui.pages.abstract.page import Page

class StartPage(Page):
    def run(self):
        self.page.add(
            flet.Text("Welcome to the Start Page!")
        )