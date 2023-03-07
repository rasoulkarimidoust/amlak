class related {

    constructor() {
        this.domain = document.domain.toString().replace('www.', '').replace('.com', '').replace('.ir', '').replace('.org', '').replace('.net', '').replace('.news', '');

        this.url = "https://newswidget.net/rss-reader/statics/undernews/patoghonline/undernews.html";

        this.relatedAsHtml = '';
        this.oldSequences = [];
        this.newSequences = [];

        /* we check to find if sequence is full or not */
        this.isOldSequenceFull();
        this.setOldSequences();
        this.showRelated();

    }

    showRelated = () => {
        var url = this.url + "?ext=" + this.queryString();
        this.relatedAsHtml = jQuery('<div>').load(url, () => {

            /* this functions finds sequences and saves them in newSequences variable and cookie */
            this.findNewSequence();

            /* save new sequence in cookie */
            this.saveSequenceInCookie('related_sequence', this.newSequences.join('====='));

            /* convert newSquence to html and upload to site*/
            this.newSequenceToHtml();

            jQuery(this.relatedAsHtml).appendTo(jQuery('#related-block-1400').html(''));
            jQuery('#mn-related-block-wrapper').addClass(this.domain + '-related-block-wrapper');
            this.overflow();
        })
    }

    queryString = () => {
        return new Date().getUTCFullYear() + '-' + new Date().getUTCMonth() + '-' + new Date().getUTCDay() + '-' + new Date().getUTCHours() + '-' + Math.floor((new Date().getUTCMinutes() / 10));
    }

    findNewSequence = () => {

        let duplicate = false;
        let finalSeq = [];

        while (!duplicate) {
            /* create a sequence */
            finalSeq = this.createSequence();
            duplicate = !this.checkNewSequenceWithOldSequence(finalSeq);
        }
        this.newSequences = finalSeq;

    }

    createSequence = () => {
        let seq = [];
        jQuery(this.relatedAsHtml).find('li').each(function () {
            seq.push(jQuery(this).attr('id'));
        })
        return this.shuffle(seq);
    }

    newSequenceToHtml = () => {
        let finalSeqAsHtml = this.newSequences.map((s) => {
            return jQuery('<div>').append(this.relatedAsHtml.find('#' + s).clone()).html();
        }).join(' ');
        this.relatedAsHtml.find('ul').html(finalSeqAsHtml);
    }

    shuffle = (array) => {
        let currentIndex = array.length,
            randomIndex;
        while (currentIndex != 0) {

            randomIndex = Math.floor(Math.random() * currentIndex);
            currentIndex--;

            [array[currentIndex], array[randomIndex]] = [
                array[randomIndex], array[currentIndex]
            ];
        }
        return array;
    }

    getSequenceFromCookie = (cname = 'related_sequence') => {
        var name = cname + "=";
        var decodedCookie = decodeURIComponent(document.cookie);
        var ca = decodedCookie.split(';');
        for (var i = 0; i < ca.length; i++) {
            var c = ca[i];
            while (c.charAt(0) == ' ') {
                c = c.substring(1);
            }
            if (c.indexOf(name) == 0) {
                this.queue = (c.substring(name.length, c.length).length == 0) ? [] : c.substring(name.length, c.length).split(',');
                return c.substring(name.length, c.length);
            }
        }
        return false;
    }

    saveSequenceInCookie = (cname, cvalue, exmin = 720) => {

        var d = new Date();
        d.setTime(d.getTime() + (exmin * 60 * 1000));
        var expires = "expires=" + d.toUTCString();
        let seqFromCookie = this.getSequenceFromCookie();
        seqFromCookie = seqFromCookie ? seqFromCookie : '';

        if (cvalue == 'reset') {
            console.log('cookie', cvalue);
            document.cookie = cname + "=;" + expires + ";path=/";
            return;
        }

        let seq = seqFromCookie.split('|||');
        seq.push(cvalue);
        seq = seq.filter(n => n);
        document.cookie = cname + "=" + seq.join('|||') + ";" + expires + ";path=/";


    }

    setOldSequences = () => {
        let seqFromCookie = this.getSequenceFromCookie();
        if (seqFromCookie.length == 0) return [];
        seqFromCookie = seqFromCookie.toString().split('|||');

        this.oldSequences = seqFromCookie.map((seq) => {
            return seq.toString().split('=====');
        })

    }

    checkNewSequenceWithOldSequence = (newSeq) => {
        if (!this.oldSequences.length) return false;
        let equal = false;
        this.oldSequences.forEach((oldSeq) => {
            if (this.arrayEquals(oldSeq, newSeq)) {
                equal = true;
                return true;
            }
        })
        return equal;
    }

    arrayEquals = (a, b) => {
        return Array.isArray(a) &&
            Array.isArray(b) &&
            a.length === b.length &&
            a.every((val, index) => val === b[index]);
    }

    isOldSequenceFull = () => {
        let oldSequence = this.getSequenceFromCookie();
        if (!oldSequence) return;

        oldSequence = oldSequence.split('|||');
        let allSeqCount = oldSequence.length;

        oldSequence = oldSequence[0];
        oldSequence = oldSequence.split('=====');
        let count = oldSequence.length;
        let tmpFactorial = this.factorial(count);

        if (+tmpFactorial - +allSeqCount < 5 || +allSeqCount > +tmpFactorial) {
            this.saveSequenceInCookie('related_sequence', 'reset');
        }

    }

    factorial = (n) => {
        //base case
        if (n == 0 || n == 1) {
            return 1;
            //recursive case
        } else {
            return n * this.factorial(n - 1);
        }
    }

    overflow = () => {
        jQuery('#mn-related-block-wrapper').closest('[class*="position-"]').css({ 'overflow': 'visible' });
    }



}


class notif {

    constructor() {
        this.domain = document.domain.toString().replace('www.', '').replace('.com', '').replace('.ir', '').replace('.org', '').replace('.net', '').replace('.news', '');
        this.shares = [];
        this.queue = [];
        this.turnValue = 0;

        this.getQueueFromCookie();
        (this.queue.length === 0) ? this.getSharesFromSite() : this.showNotif();

    }

    getQueueFromCookie = (cname = 'notif_queue') => {
        var name = cname + "=";
        var decodedCookie = decodeURIComponent(document.cookie);
        var ca = decodedCookie.split(';');
        for (var i = 0; i < ca.length; i++) {
            var c = ca[i];
            while (c.charAt(0) == ' ') {
                c = c.substring(1);
            }
            if (c.indexOf(name) == 0) {
                this.queue = (c.substring(name.length, c.length).length == 0) ? [] : c.substring(name.length, c.length).split(',');
                return c.substring(name.length, c.length);
            }
        }
        return false;
    }

    getSharesFromSite = () => {
        var url = "https://newswidget.net/rss-reader/statics/notif/" + this.domain + "/shares.html?ext=" + this.queryString();
        var sharesAsHtml = jQuery('<div>').load(url, () => {
            this.afterSharesGotten(sharesAsHtml);
        })
    }

    afterSharesGotten = (sharesAsHtml) => {

        /* Shares are not fount from cookies then it must get it from website, and sets shares variable */
        this.setShares(sharesAsHtml.html());

        /* we find Whose turn it is */
        this.setQueueValue();

        /* We run this function and it saves datas in this.queue */
        this.queueMaker();

        /* we save queues as cookie */
        this.saveQueueInCookie();

        /* we know shares, we know the turn */
        this.showNotif();

    }

    setShares = (sharesAsHtml) => {
        let spans = jQuery(sharesAsHtml).find('span');
        spans.each((index) => {
            this.shares[index] = spans.eq(index).attr('data-file').split(',');
        })
    }

    saveQueueInCookie = () => {
        this.setCookie('notif_queue', this.queue.join(','));
    }

    showNotif = () => {
        let turn = this.queue[0];
        this.queue.shift();
        this.saveQueueInCookie();

        var url = "https://newswidget.net/rss-reader/statics/notif/" + this.domain + '/' + this.domain + '-' + turn + '.html?' + this.queryString();

        var wrapper = jQuery('<div>').load(url, function () {
            jQuery(wrapper).appendTo('body').fadeIn(0);
        })
    }

    queryString = () => {
        return new Date().getUTCFullYear() + '-' + new Date().getUTCMonth() + '-' + new Date().getUTCDay() + '-' + new Date().getUTCHours() + '-' + Math.floor((new Date().getUTCMinutes() / 10));
    }

    queueMaker = () => {
        this.queue = [];
        let pos = [],
            len = 0;

        for (var i = 0; i < this.shares.length; i++) /* first dimension */
            for (var j = 0; j < this.shares[i].length; j++) /* second dimension */
                if (this.shares[i][j] == this.turnValue)
                    pos = i;

        for (var j = 0; j < 30; j++) { /* second dimension */
            for (var i = 0; i < this.shares.length; i++) { /* first dimension */
                let index = (pos + i) % this.shares.length;
                if (this.shares[index]) {
                    if (this.shares[index].length > j) { /* We have not read this row yet. we didn`t reached the end */
                        if (this.shares[index][j]) {
                            this.queue[len++] = this.shares[index][j];
                        }
                    }
                }
            }
        }

        return this.queue;
    }

    setCookie = (cname, cvalue, exmin = 720) => {
        var d = new Date();
        d.setTime(d.getTime() + (exmin * 60 * 1000));
        var expires = "expires=" + d.toUTCString();
        document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
    }

    setQueueValue = () => {
        this.turnValue = (new Date().getUTCSeconds()) % 20;
    }

}


/*****************************************/
/***************** Click *****************/
/*****************************************/

class Click {

    destinationHistory = [];
    domains = [];
    destination = '';
    show = false;

    constructor() {
        this.constructorSecond();
        console.log('click ran');
    }

    async constructorSecond() {

        var extension = new Date().getUTCFullYear() + '-' + new Date().getUTCMonth() + '-' + new Date().getUTCDay() + '-' + new Date().getUTCHours() + '-' + Math.floor((new Date().getUTCMinutes() / 10));
        var response = await fetch('https://files.newswidget.net/clicks.json?' + extension + 1);
        this.show && console.log('response.status', response.status);
        if (response.status != 200) {
            this.show && console.log('cannot get data');
            this.domains = [
                "https://khabaremelat.com/inframe.php?url=",
            ];
        }


        var sites = await response.json();
        sites.forEach((site) => {
            this.domains.push(site.url);
        })

        this.show && console.log(this.domains);

        /* now we have all domains to redirect to */

        this.getDestinationHistory();
        this.findDestination();

        this.show && console.log(this.destination);

        var domain = 'https://' + document.location.host;
        jQuery('a[href^="/"], a[href^="' + domain + '"]')
            .not('a[href*="/advertisements/"]')
            .click((e) => {

                this.setClickHistoryCookie();
                /* if (this.getClickHistoryCookie() != 2) {
                    return;
                } */

                var that = jQuery(e.currentTarget);
                if (that.attr('href').toString().search("https://") == -1) {
                    var src = this.destination + domain + that.attr('href');
                } else {
                    var src = this.destination + that.attr('href');
                }
                window.open(src);

            })
    }

    findDestination() {

        if (this.equalsIgnoreOrder(this.domains, this.destinationHistory)) {
            this.destinationHistory = [];
            this.setCookie('__destinationSites', '');
            this.show && console.log('all sites are seen, all history is deleted');
        }

        var found = false;
        var index = 0;
        while (!found) {
            index = (new Date().getMilliseconds()) % this.domains.length;
            var result = this.destinationHistory.find((dest) => { return dest == this.domains[index]; });
            if (result === undefined) {
                found = true;
            }
        }

        this.addDestination(this.domains[index]);
        this.show && console.log(this.domains[index] + ' is added to history');
        this.destination = this.domains[index];
        return this.destination;
    }

    setCookie(cname, cvalue, exdays = 1) {
        const d = new Date();
        d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
        let expires = "expires=" + d.toUTCString();
        document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
    }

    getCookie(cname) {
        let name = cname + "=";
        let decodedCookie = decodeURIComponent(document.cookie);
        let ca = decodedCookie.split(';');
        for (let i = 0; i < ca.length; i++) {
            let c = ca[i];
            while (c.charAt(0) == ' ') {
                c = c.substring(1);
            }
            if (c.indexOf(name) == 0) {
                return c.substring(name.length, c.length);
            }
        }
        return "";
    }

    setClickHistoryCookie() {
        var clickCount = this.getCookie('__clickHistory');
        clickCount = clickCount == "" ? 1 : parseInt(clickCount) + 1;
        this.setCookie('__clickHistory', clickCount);
    }

    getClickHistoryCookie() {
        return parseInt(this.getCookie('__clickHistory'));
    }

    addDestination(destination) {
        this.destinationHistory.push(destination);
        var dest = this.destinationHistory.join('|||');
        this.setCookie('__destinationSites', dest);
    }

    getDestinationHistory() {
        var dest = this.getCookie('__destinationSites');
        this.destinationHistory = dest.length == 0 ? [] : dest.toString().split('|||');
        this.show && console.log(this.destinationHistory);
        return this.destinationHistory;
    }

    equalsIgnoreOrder(a, b) {
        if (a.length !== b.length) return false;
        const uniqueValues = new Set([...a, ...b]);
        for (const v of uniqueValues) {
            const aCount = a.filter(e => e === v).length;
            const bCount = b.filter(e => e === v).length;
            if (aCount !== bCount) return false;
        }
        return true;
    }

}


let interval = setInterval(() => {
    if (typeof jQuery === 'undefined') { } else {
        console.log(typeof jQuery);
        jQuery(document).ready(() => {
            new related();
            /* new Click(); */
            new notif();
        })
        clearInterval(interval);
    }
}, 500);