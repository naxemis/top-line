import flet

from ui.app import App

def main(page: flet.Page):
    app = App(page)
    app.run_current_page()

if __name__ == "__main__":
    flet.app(target=main)











