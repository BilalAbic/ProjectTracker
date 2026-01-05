/**
 * ProjectTracker - Invite Acceptance Page
 * Handles invitation token validation and acceptance
 */

// API Base URL - Loaded from config.js
// CONFIG.API_BASE_URL = 'https://bilalabic.com' (base domain)
// API endpoints: /api/invitations/...
const API_BASE_URL = typeof CONFIG !== 'undefined' ? CONFIG.API_BASE_URL : 'http://localhost:5000';
const DEMO_MODE = typeof CONFIG !== 'undefined' ? CONFIG.DEMO_MODE : true;

// DOM Elements
const loadingState = document.getElementById('loadingState');
const inviteContent = document.getElementById('inviteContent');
const errorState = document.getElementById('errorState');
const successState = document.getElementById('successState');
const errorMessage = document.getElementById('errorMessage');

// Invite data elements
const teamNameEl = document.getElementById('teamName');
const invitedByEl = document.getElementById('invitedBy');
const proposedRoleEl = document.getElementById('proposedRole');
const expiresAtEl = document.getElementById('expiresAt');

// Buttons
const btnAccept = document.getElementById('btnAccept');
const btnDecline = document.getElementById('btnDecline');

// Current invitation token
let currentToken = null;

/**
 * Initialize page
 */
document.addEventListener('DOMContentLoaded', () => {
    // Get token from URL
    const urlParams = new URLSearchParams(window.location.search);
    currentToken = urlParams.get('token');

    if (!currentToken) {
        showError('Davet linki geçersiz. Lütfen e-postanızdaki linki kontrol edin.');
        return;
    }

    // Load invitation details
    loadInvitation(currentToken);

    // Setup button handlers
    btnAccept.addEventListener('click', handleAccept);
    btnDecline.addEventListener('click', handleDecline);
});

/**
 * Load invitation details from API
 */
async function loadInvitation(token) {
    showLoading();

    // Demo mode - simulated data
    if (DEMO_MODE) {
        setTimeout(() => {
            const demoInvite = {
                teamName: 'Development Team',
                invitedBy: 'Bilal Abiç',
                proposedRole: 'Developer',
                expiresAt: new Date(Date.now() + 7 * 24 * 60 * 60 * 1000).toISOString(),
                isValid: true
            };
            displayInvitation(demoInvite);
        }, 1500);
        return;
    }

    // Production API call
    try {
        const response = await fetch(`${API_BASE_URL}/api/invitations/validate?token=${token}`);
        const data = await response.json();

        if (response.ok && data.isValid) {
            displayInvitation(data);
        } else {
            showError(data.message || 'Davet bulunamadı.');
        }
    } catch (error) {
        console.error('Error loading invitation:', error);
        showError('Davet bilgileri yüklenirken bir hata oluştu.');
    }
}

/**
 * Display invitation details
 */
function displayInvitation(invite) {
    teamNameEl.textContent = invite.teamName;
    invitedByEl.textContent = invite.invitedBy;
    proposedRoleEl.textContent = invite.proposedRole;
    
    const expiresDate = new Date(invite.expiresAt);
    const daysLeft = Math.ceil((expiresDate - new Date()) / (1000 * 60 * 60 * 24));
    expiresAtEl.textContent = `${formatDate(expiresDate)} (${daysLeft} gün kaldı)`;

    showContent();
}

/**
 * Handle accept button click
 */
async function handleAccept() {
    btnAccept.disabled = true;
    btnAccept.innerHTML = '<span class="spinner-small"></span> İşleniyor...';

    // Demo mode
    if (DEMO_MODE) {
        setTimeout(() => {
            showSuccess();
        }, 1500);
        return;
    }

    // Production API call
    try {
        const response = await fetch(`${API_BASE_URL}/api/invitations/accept`, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ token: currentToken })
        });

        if (response.ok) {
            showSuccess();
        } else {
            const data = await response.json();
            alert(data.message || 'Davet kabul edilirken bir hata oluştu.');
            btnAccept.disabled = false;
            btnAccept.innerHTML = '<span>✅</span> Daveti Kabul Et';
        }
    } catch (error) {
        console.error('Error accepting invitation:', error);
        alert('Bir hata oluştu. Lütfen tekrar deneyin.');
        btnAccept.disabled = false;
        btnAccept.innerHTML = '<span>✅</span> Daveti Kabul Et';
    }
}

/**
 * Handle decline button click
 */
async function handleDecline() {
    if (!confirm('Daveti reddetmek istediğinizden emin misiniz?')) {
        return;
    }

    btnDecline.disabled = true;
    btnDecline.innerHTML = 'İşleniyor...';

    // Demo mode
    if (DEMO_MODE) {
        setTimeout(() => {
            showError('Daveti reddettiniz.');
        }, 1000);
        return;
    }

    // Production API call
    try {
        const response = await fetch(`${API_BASE_URL}/api/invitations/decline`, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ token: currentToken })
        });

        if (response.ok) {
            showError('Daveti reddettiniz.');
        } else {
            alert('Bir hata oluştu.');
            btnDecline.disabled = false;
            btnDecline.innerHTML = '<span>❌</span> Reddet';
        }
    } catch (error) {
        console.error('Error declining invitation:', error);
        alert('Bir hata oluştu.');
        btnDecline.disabled = false;
        btnDecline.innerHTML = '<span>❌</span> Reddet';
    }
}

/**
 * UI State helpers
 */
function showLoading() {
    loadingState.style.display = 'block';
    inviteContent.style.display = 'none';
    errorState.style.display = 'none';
    successState.style.display = 'none';
}

function showContent() {
    loadingState.style.display = 'none';
    inviteContent.style.display = 'block';
    errorState.style.display = 'none';
    successState.style.display = 'none';
}

function showError(message) {
    loadingState.style.display = 'none';
    inviteContent.style.display = 'none';
    errorState.style.display = 'block';
    successState.style.display = 'none';
    errorMessage.textContent = message;
}

function showSuccess() {
    loadingState.style.display = 'none';
    inviteContent.style.display = 'none';
    errorState.style.display = 'none';
    successState.style.display = 'block';
}

/**
 * Format date helper
 */
function formatDate(date) {
    const options = { day: 'numeric', month: 'long', year: 'numeric' };
    return date.toLocaleDateString('tr-TR', options);
}
