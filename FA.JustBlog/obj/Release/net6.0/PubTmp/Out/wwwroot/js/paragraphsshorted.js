class readMore {
    constructor() {
        this.content = '.readmore__content';
        this.buttonToggle = '.readmore__toggle';
    }
    bootstrap() {
        this.setNodes();
        this.init();
        this.addEventListeners();
    }
    setNodes() {
        this.nodes = {
            contentToggles: document.querySelectorAll(this.content)
        };
        this.buttonToggles = document.querySelectorAll(this.buttonToggle);
    }
    init() {
        const { contentToggles } = this.nodes;
        contentToggles.forEach((contentToggle) => {
            const stateContent = contentToggle.innerHTML;
            contentToggle.innerHTML = `${stateContent.substring(0, 100)}...`;
            contentToggle.setAttribute('data-state-content', stateContent);
        });
    }
    addEventListeners() {
        this.buttonToggles.forEach((buttonToggle, index) => {
            const contentToggle = this.nodes.contentToggles[index];
            const stateContent = contentToggle.getAttribute('data-state-content');



            buttonToggle.addEventListener('click', () => {
                if (buttonToggle.getAttribute('aria-checked') === 'true') {
                    buttonToggle.setAttribute('aria-checked', 'false');
                    contentToggle.innerHTML = `${stateContent.substring(0, 100)}...`;
                    buttonToggle.innerHTML = '...more';
                } else {
                    buttonToggle.setAttribute('aria-checked', 'true');
                    contentToggle.innerHTML = stateContent;
                    buttonToggle.innerHTML = '<--less';
                }
            });
        });
    }
}
const initReadMore = new readMore();
initReadMore.bootstrap();